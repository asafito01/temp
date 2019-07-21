Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports ObserveItApp

Public Class FlightManager
	Inherits BaseManager
	Implements IFlightManager

	Private ReadOnly DbProvider As IDbProvider
	Private ReadOnly Logger As ILogger
	Private ReadOnly AirportManager As IAirportManager
	Private ReadOnly PlaneManager As IPlaneManager

	Public Sub New(_PlaneManager As IPlaneManager, _AirportManager As IAirportManager, _DbProvider As IDbProvider, _Logger As ILogger)
		If _DbProvider Is Nothing Then Throw New ArgumentNullException(NameOf(_DbProvider))
		DbProvider = _DbProvider

		If _Logger Is Nothing Then Throw New ArgumentNullException(NameOf(_Logger))
		Logger = _Logger

		If _PlaneManager Is Nothing Then Throw New ArgumentNullException(NameOf(_PlaneManager))
		PlaneManager = _PlaneManager

		If _AirportManager Is Nothing Then Throw New ArgumentNullException(NameOf(_AirportManager))
		AirportManager = _AirportManager
	End Sub

	Public Overrides Async Function ConvertEntityAsync(sdr As SqlDataReader) As Task(Of BaseModel)
		Dim flightData As New FlightModel With {
			.ID = sdr.Item("flightID"),
			.DepartureDate = sdr.Item("flightDepartureDate"),
			.ArrivalDate = sdr.Item("flightArrivalDate"),
			.Code = sdr.Item("flightCode")
		}

		'flightData.DepartureAirport = Await AirportManager.GetSingleAsync(sdr.Item("departureAirportID"))
		'flightData.ArrivalAirport = Await AirportManager.GetSingleAsync(sdr.Item("arrivalAirportID"))
		'flightData.Plane = Await PlaneManager.GetSingleAsync(sdr.Item("planeID"))

		Return flightData
	End Function


	Private Async Function GetAllAsync() As Task(Of IEnumerable(Of BaseModel)) Implements IFlightManager.GetAllAsync
		Dim flightsList As New List(Of BaseModel)
		Dim q As String = "SELECT * FROM tbFlights"
		Using sdr As SqlDataReader = Await DbProvider.ExecuteReaderAsync(q, Nothing)
			While sdr.Read
				'	flightsList.Add(Await ConvertEntityAsync(sdr))
			End While
			sdr.Close()
		End Using
		Return flightsList.AsEnumerable
	End Function
End Class
