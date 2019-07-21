Imports System.ComponentModel
Imports System.Data.SqlClient
Imports ObserveItApp

Public Class DbProvider
	Implements IDbProvider

	Public ReadOnly Property DbConnectionStringProvider As IDbConnectionStringProvider Implements IDbProvider.DbConnectionStringProvider
	Public ReadOnly Property Logger As ILogger

	Public Sub New(_DbConnectionStringProvider As IDbConnectionStringProvider, _Logger As ILogger)
		If _DbConnectionStringProvider Is Nothing Then Throw New ArgumentNullException(NameOf(_DbConnectionStringProvider))
		DbConnectionStringProvider = _DbConnectionStringProvider

		If _Logger Is Nothing Then Throw New ArgumentNullException(NameOf(_Logger))
		Logger = _Logger

		' Log object initiation
		Logger.Log(LoggerLogTypes.Information, "DbProvider created")
	End Sub

	Public Function ExecuteDataTable(sql As String, params() As IDbDataParameter) As IListSource Implements IDbProvider.ExecuteDataTable
		Using cmd As New SqlCommand
			Try
				Using conn As New SqlConnection(DbConnectionStringProvider.DbConnectionString)
					cmd.Connection = conn
					cmd.CommandText = sql
					cmd.Connection.Open()

					Dim dt As New DataTable
					If Not params Is Nothing Then cmd.Parameters.AddRange(params)
					Using sdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
						If sdr.HasRows Then
							dt.Load(sdr)
						End If
					End Using
					Return dt
				End Using
			Catch ex As Exception
				If cmd IsNot Nothing AndAlso cmd.Connection IsNot Nothing Then cmd.Connection.Close()
				Throw New Exception(ex.ToString)
			End Try
		End Using
	End Function

	Public Async Function ExecuteDataTableAsync(sql As String, params() As IDbDataParameter) As Threading.Tasks.Task(Of IListSource) Implements IDbProvider.ExecuteDataTableAsync
		Using cmd As New SqlCommand
			Try
				Using conn As New SqlConnection(DbConnectionStringProvider.DbConnectionString)
					cmd.Connection = conn
					cmd.CommandText = sql
					cmd.Connection.Open()

					Dim dt As New DataTable
					If Not params Is Nothing Then cmd.Parameters.AddRange(params)
					Using sdr As SqlDataReader = Await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection)
						If sdr.HasRows Then
							dt.Load(sdr)
						End If
					End Using
					Return dt
				End Using
			Catch ex As Exception
				If cmd IsNot Nothing AndAlso cmd.Connection IsNot Nothing Then cmd.Connection.Close()
				Throw New Exception(ex.ToString)
			End Try
		End Using
	End Function

	Public Function ExecuteReader(sql As String, params() As IDbDataParameter) As IDataReader Implements IDbProvider.ExecuteReader
		Using cmd As New SqlCommand
			Try
				Dim conn As New SqlConnection(DbConnectionStringProvider.DbConnectionString)
				cmd.Connection = conn
				cmd.CommandText = sql
				cmd.Connection.Open()
				If Not params Is Nothing Then cmd.Parameters.AddRange(params)
				Return cmd.ExecuteReader(CommandBehavior.CloseConnection)
			Catch ex As Exception
				If cmd IsNot Nothing AndAlso cmd.Connection IsNot Nothing Then cmd.Connection.Close()
				Throw New Exception(ex.ToString)
			End Try
		End Using
	End Function

	Public Async Function ExecuteReaderAsync(sql As String, params() As IDbDataParameter) As Threading.Tasks.Task(Of IDataReader) Implements IDbProvider.ExecuteReaderAsync
		Using cmd As New SqlCommand
			Try
				Dim conn As New SqlConnection(DbConnectionStringProvider.DbConnectionString)
				cmd.Connection = conn
				cmd.CommandText = sql
				cmd.Connection.Open()
				If Not params Is Nothing Then cmd.Parameters.AddRange(params)
				Return Await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection)
			Catch ex As Exception
				If cmd IsNot Nothing AndAlso cmd.Connection IsNot Nothing Then cmd.Connection.Close()
				Throw New Exception(ex.ToString)
			End Try
		End Using
	End Function
End Class
