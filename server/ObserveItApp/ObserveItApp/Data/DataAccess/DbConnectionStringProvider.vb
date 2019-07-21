Imports ObserveItApp

Public Class DbConnectionStringProvider
	Implements IDbConnectionStringProvider
	Public ReadOnly Property DbConnectionString As String Implements IDbConnectionStringProvider.DbConnectionString
		Get
			Return ConfigurationManager.ConnectionStrings.Item("sqlConnectionString").ConnectionString
		End Get
	End Property
End Class
