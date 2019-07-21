Imports System.Net
Imports System.Threading.Tasks
Imports System.Web.Http

Namespace Controllers
	<RoutePrefix("api/v1/flights")>
	Public Class FlightsController
		Inherits ApiController

		Private ReadOnly Logger As ILogger
		Private ReadOnly FlightManager As IFlightManager

		Public Sub New(_FlightManager As IFlightManager, _Logger As ILogger)
			' Initiate flights service
			If _FlightManager Is Nothing Then Throw New ArgumentNullException(NameOf(_FlightManager))
			FlightManager = _FlightManager

			' Initiate logger
			If _Logger Is Nothing Then Throw New ArgumentNullException(NameOf(_Logger))
			Logger = _Logger
		End Sub

		<HttpGet>
		<Route("")>
		Public Async Function GetAllAsync(<FromUri> Optional airport As String = Nothing, <FromUri> Optional d As Date = Nothing) As Task(Of IHttpActionResult)
			Throw New NotSupportedException
			'Dim flights As List(Of BaseModel) = Await FlightManager.GetAllAsync()
			'Return Ok(flights)
		End Function

		<HttpGet>
		<Route("departures")>
		Public Async Function GetDeparturesAsync(<FromUri> Optional airport As String = Nothing, <FromUri> Optional d As Nullable(Of Date) = Nothing) As Task(Of IHttpActionResult)
			Throw New NotSupportedException
		End Function

		<HttpGet>
		<Route("arrivals")>
		Public Async Function GetArrivalsAsync(<FromUri> Optional airport As String = Nothing, <FromUri> Optional d As Nullable(Of Date) = Nothing) As Task(Of IHttpActionResult)
			Throw New NotSupportedException
		End Function
	End Class
End Namespace