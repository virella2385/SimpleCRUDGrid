To run

1. Make sure to have the CLI Dotnet Core tools installed. As well as a SQL Server login that's a dbcreator role.
2.	Change the connection in appsetting.Development.json to your own.
3.	Open the terminal/command prompt
	*	dotnet ef migrations add InitialCreate
	*	dotnet ef database update
	*	dotnet run