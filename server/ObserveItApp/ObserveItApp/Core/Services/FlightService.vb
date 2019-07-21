Imports System.Threading.Tasks
Imports ObserveItApp

Public Class FlightService
	Implements IFlightService

	Private ReadOnly FlightManager As IFlightManager

	Public Sub New(_FlightManager As IFlightManager)
		FlightManager = _FlightManager
	End Sub

	Private Async Function GetAllAsync() As Task(Of IEnumerable(Of BaseModel)) Implements IFlightService.GetAllAsync
		Return Await FlightManager.GetAllAsync()
	End Function

	Public Function GetDeparturesAsync(airport As String, d As Date?) As Task(Of IEnumerable(Of BaseModel)) Implements IFlightService.GetDeparturesAsync
		Throw New NotImplementedException()
	End Function

	Public Function GetArrivalsAsync(airport As String, d As Date?) As Task(Of IEnumerable(Of BaseModel)) Implements IFlightService.GetArrivalsAsync
		Throw New NotImplementedException()
	End Function


End Class
