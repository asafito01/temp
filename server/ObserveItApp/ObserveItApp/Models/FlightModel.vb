Public Class FlightModel
	Inherits BaseModel

	Public Property ID As Integer
	Public Property Code As String
	Public Property Plane As PlaneModel
	Public Property DepartureDate As Date
	Public Property ArrivalDate As Date
	Public Property DepartureAirport As AirportModel
	Public Property ArrivalAirport As AirportModel
	Public Property CrewMembers As List(Of UserModel)
	Public Property AssignedSeats As Dictionary(Of SeatModel, UserModel)
End Class
