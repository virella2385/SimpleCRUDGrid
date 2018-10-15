# Dotnet Core MVC CRUD web app

This web app uses the jquery [datatable plugin][https://datatables.net/], some jquery for ajax calls, tags helpers, data annotations 
for field properties and validations. Hopefully you can find this code useful. Any suggestions, please don't hesitate to do a pull 
request.

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
