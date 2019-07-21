Imports System.Data.SqlClient
Imports System.Threading.Tasks

Public Interface IAirportManager
	Function GetSingleAsync(id As Integer) As Task(Of IEnumerable(Of BaseModel))
End Interface
