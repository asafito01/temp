Public Class PlaneModel
	Inherits BaseModel

	Public Property ID As Integer
	Public Property Model As PlaneModels
	Public Property Company As String
	Public Property NumberOfRows As Integer
	Public Property NumberOfSeatsPerRow As Integer

	Public Enum PlaneModels
		[Boeing747]
		[Boeing737]
		[Boeing777]
	End Enum
End Class
