Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports ObserveItApp

Public Class PlaneManager
	Inherits BaseManager
	Implements IPlaneManager

	Private ReadOnly DbProvider As IDbProvider
	Private ReadOnly Logger As ILogger

	Public Sub New(_DbProvider As IDbProvider, _Logger As ILogger)
		If _DbProvider Is Nothing Then Throw New ArgumentNullException(NameOf(_DbProvider))
		DbProvider = _DbProvider

		If _Logger Is Nothing Then Throw New ArgumentNullException(NameOf(_Logger))
		Logger = _Logger

		' Log object initiation
		Logger.Log(LoggerLogTypes.Information, "Products Manager created")
	End Sub

	Public Overrides Async Function ConvertEntityAsync(sdr As SqlDataReader) As Task(Of BaseModel)
		Dim planeData As BaseModel = New PlaneModel With {
			.ID = sdr.Item("planeID"),
			.Model = sdr.Item("planeModel"),
			.Company = sdr.Item("planeCompany"),
			.NumberOfRows = sdr.Item("planeRows"),
			.NumberOfSeatsPerRow = sdr.Item("planeSeatsPerRow")
		}

		Return planeData
	End Function

	Private Async Function GetSingleAsync(id As Integer) As Task(Of BaseModel) Implements IPlaneManager.GetSingleAsync
		Dim plane As New PlaneModel
		Using sdr As SqlDataReader = Await DbProvider.ExecuteReaderAsync("SELECT * FROM tbPlanes WHERE (planeID = @planeID)", {New SqlParameter("planeID", SqlDbType.Int) With {.Value = id}})
			While sdr.Read
				plane = Await ConvertEntityAsync(sdr)
			End While
			sdr.Close()
		End Using
		Return plane
	End Function
End Class
