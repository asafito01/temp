Imports System.Threading.Tasks

Public Interface IFlightService
	Function GetAllAsync() As Task(Of IEnumerable(Of BaseModel))
	Function GetDeparturesAsync(airport As String, d As Date?) As Task(Of IEnumerable(Of BaseModel))
	Function GetArrivalsAsync(airport As String, d As Date?) As Task(Of IEnumerable(Of BaseModel))
End Interface
