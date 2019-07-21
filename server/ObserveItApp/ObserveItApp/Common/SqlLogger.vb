Imports Serilog

Public Class SqlLogger
	Implements ILogger

	Private Logger As Core.Logger

	Public Sub New(dbConnectionString As String, tableName As String)
		Dim jsonFormatter As New Formatting.Json.JsonFormatter()
		Logger = New LoggerConfiguration().MinimumLevel.Debug().WriteTo().MSSqlServer(dbConnectionString, tableName, autoCreateSqlTable:=True).CreateLogger()

		' Log object initiation
		Me.Log(LoggerLogTypes.Information, "SqlLogger created")
	End Sub

	Public Sub Log(type As LoggerLogTypes, message As String) Implements ILogger.Log
		Select Case type
			Case LoggerLogTypes.Information
				Logger.Information(message)

			Case LoggerLogTypes.Error
				Logger.Error(message)
		End Select
	End Sub
End Class
