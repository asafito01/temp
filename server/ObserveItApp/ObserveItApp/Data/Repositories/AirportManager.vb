Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports ObserveItApp

Public Class AirportManager
	Inherits BaseManager
	Implements IAirportManager

	Private ReadOnly DbProvider As IDbProvider
	Private ReadOnly Logger As ILogger
	Private ReadOnly AirportManager As IAirportManager

	Public Sub New(_AirportManager As IAirportManager, _DbProvider As IDbProvider, _Logger As ILogger)
		If _DbProvider Is Nothing Then Throw New ArgumentNullException(NameOf(_DbProvider))
		DbProvider = _DbProvider

		If _Logger Is Nothing Then Throw New ArgumentNullException(NameOf(_Logger))
		Logger = _Logger

		If _AirportManager Is Nothing Then Throw New ArgumentNullException(NameOf(_AirportManager))
		AirportManager = _AirportManager
	End Sub

	Public Overrides Async Function ConvertEntityAsync(sdr As SqlDataReader) As Task(Of BaseModel)
		Dim airportData As New AirportModel With {
			.ID = sdr.Item("airportID"),
			.Code = sdr.Item("airportCode"),
			.Country = sdr.Item("airportCountry")
			}
		Return airportData
	End Function

	Public Async Function GetSingleAsync(id As Integer) As Task(Of IEnumerable(Of BaseModel)) Implements IAirportManager.GetSingleAsync
		Dim airport As New AirportModel
		Using sdr As SqlDataReader = Await DbProvider.ExecuteReaderAsync("SELECT * FROM tbAirports WHERE (airportID = @airportID)", {New SqlParameter("airportID", SqlDbType.Int) With {.Value = id}})
			While sdr.Read
				airport = Await ConvertEntityAsync(sdr)
			End While
			sdr.Close()
		End Using
		Return airport
	End Function

End Class
