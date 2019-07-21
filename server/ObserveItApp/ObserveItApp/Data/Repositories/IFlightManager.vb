Imports System.Data.SqlClient
Imports System.Threading.Tasks

Public Interface IFlightManager
	Function GetAllAsync() As Task(Of IEnumerable(Of BaseModel))
End Interface
