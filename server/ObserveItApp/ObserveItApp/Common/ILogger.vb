Public Interface ILogger
	Sub Log(type As LoggerLogTypes, message As String)
End Interface

Public Enum LoggerLogTypes
	[Information]
	[Error]
End Enum