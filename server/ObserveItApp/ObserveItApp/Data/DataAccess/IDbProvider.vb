Imports System.ComponentModel
Imports System.Threading.Tasks

Public Interface IDbProvider
	ReadOnly Property DbConnectionStringProvider As IDbConnectionStringProvider
	Function ExecuteReader(sql As String, params() As IDbDataParameter) As IDataReader
	Function ExecuteReaderAsync(sql As String, params() As IDbDataParameter) As Task(Of IDataReader)
	Function ExecuteDataTable(sql As String, params() As IDbDataParameter) As IListSource
	Function ExecuteDataTableAsync(sql As String, params() As IDbDataParameter) As Task(Of IListSource)
End Interface
