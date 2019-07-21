Imports System.Text
Imports System.Web.Http.Results
Imports Xunit
Imports Moq
Imports ObserveItApp.Controllers

<TestClass()> Public Class FlightControllerTest
	Protected FlightService As Mock(Of IFlightService)
	Protected LoggerMock As Mock(Of ILogger)
	Protected ItemUnderTest As FlightsController

	Public Sub New()
		FlightService = New Mock(Of IFlightService)
		LoggerMock = New Mock(Of ILogger)
		ItemUnderTest = New FlightsController(FlightService, LoggerMock.Object)
	End Sub

	<TestClass()> Public Class GetAllAsync
		Inherits FlightControllerTest

		<TestMethod()>
		Public Async Function ShouldReturnOkWithFlights() As Task
			' Arrange
			Dim airportCode As String = "TLV"
			Dim dateToCheck As Date = Date.Today
			Dim departureDate As Date = dateToCheck.AddDays(-1)
			Dim arrivalDate As Date = dateToCheck

			Dim expectedFlights() As FlightModel = {
				New FlightModel With {.ID = 1, .Code = "AAA", .DepartureDate = departureDate, .ArrivalDate = arrivalDate},
				New FlightModel With {.ID = 2, .Code = "BBB", .DepartureDate = departureDate, .ArrivalDate = arrivalDate},
				New FlightModel With {.ID = 3, .Code = "CCC", .DepartureDate = departureDate, .ArrivalDate = arrivalDate}
			}

			' Act
			Dim result = Await ItemUnderTest.GetAllAsync(airportCode, dateToCheck)
			Dim resultData = DirectCast(result, OkNegotiatedContentResult(Of IEnumerable(Of PlaneModel))).Content

			' Assert
			Dim expectedType As Type = GetType(System.Web.Http.Results.OkNegotiatedContentResult(Of IEnumerable(Of FlightModel)))
			Dim actualType As Type = result.GetType
			Assert.Equal(expectedType, actualType)
			Assert.Same(expectedFlights, resultData)
		End Function

	End Class

End Class