Imports System.Data.SqlClient
Imports System.Threading.Tasks

Public Interface IPlaneManager
	Function GetSingleAsync(id As Integer) As Task(Of BaseModel)
End Interface
