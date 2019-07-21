Imports System.Data.SqlClient

Public MustInherit Class BaseManager
	MustOverride Async Function ConvertEntityAsync(sdr As SqlDataReader) As Threading.Tasks.Task(Of BaseModel)
End Class
