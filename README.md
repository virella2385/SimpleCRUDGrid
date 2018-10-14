# Dotnet Core MVC CRUD web app

*Note: Uses code first approach*

To run

1. Make sure to have the CLI Dotnet Core tools installed. As well as a SQL Server login that's a dbcreator role.
2.	Change the connection string in appsetting.Development.json to your own.
3.	Open the terminal/command prompt
	*	dotnet ef migrations add InitialCreate
		* Run only once to create the DB
		* Run *SeedData.sql* in a SQL management studio (I use Azure Data Studio from a mac).
	*	dotnet ef database update
		* Run every time to update DB schema. If you get a message saying there are no new migrations
	      skip to the next command.
	*	dotnet run
