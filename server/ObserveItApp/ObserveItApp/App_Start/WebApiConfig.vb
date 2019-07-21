Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http
Imports Unity.AspNet.WebApi
Imports Unity
Imports Unity.Lifetime
Imports Unity.Resolution

Public Module WebApiConfig
	Public Sub Register(ByVal config As HttpConfiguration)
		' Dependency injection resolver using Unity for WebApi
		Dim container = New UnityContainer

		'	container.RegisterType(Of IFlightMapper, FlightMapper)(New ContainerControlledLifetimeManager())
		container.RegisterType(Of IDbProvider, DbProvider)(New ContainerControlledLifetimeManager())
		container.RegisterType(Of IDbConnectionStringProvider, DbConnectionStringProvider)(New ContainerControlledLifetimeManager())
		container.RegisterType(Of IAirportManager, AirportManager)(New ContainerControlledLifetimeManager())
		container.RegisterType(Of IPlaneManager, PlaneManager)(New ContainerControlledLifetimeManager())
		container.RegisterType(Of IFlightManager, FlightManager)(New ContainerControlledLifetimeManager())

		container.RegisterType(Of ILogger, SqlLogger)(New ContainerControlledLifetimeManager())
		container.Resolve(Of ILogger)(New ParameterOverride("dbConnectionString", ConfigurationManager.ConnectionStrings.Item("sqlConnectionString").ConnectionString), New ParameterOverride("tableName", "tbActivityLog"))
		config.DependencyResolver = New UnityDependencyResolver(container)

		' Web API configuration and services
		' Web API routes
		config.MapHttpAttributeRoutes()

		config.Formatters.XmlFormatter.SupportedMediaTypes.Clear()
		config.Formatters.JsonFormatter.Indent = True

		'' Flights
		'config.Routes.MapHttpRoute(
		'	name:="FlightsApi",
		'	routeTemplate:="api/v1/flights/{action}",
		'	defaults:=New With {.controller = "flights"}
		')

		'config.Routes.MapHttpRoute(
		'	name:="DefaultApi",
		'	routeTemplate:="api/v1/{controller}/{id}",
		'	defaults:=New With {.id = RouteParameter.Optional}
		')
	End Sub
End Module
