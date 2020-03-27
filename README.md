# RssFeeder

## Running the application

If you are going to run the application, you will need SQL Server and Visual Studio.  The developer edition is all you will be needing and it can be acquired [here](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).

To setup the database, right-click on the `RssFeeder` project and select `Manage User Secrets`.  Inside of the JSON, enter the following:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=RssFeeder;Trusted_Connection=True;MultipleActiveResultSets=true"
 }
```

You will need to download the Entity Framework CLI tool to run the database migrations and it can be downloaded [here](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet).  Open a terminal and navigate into the project (not the solution) and run the following command: `dotnet ef migrations add InitialProjectMigration`.  After the project is built and the migration is complete, run the command `dotnet ef database update` to create the database tables.  The application should be ready to go.

If there are any errors, feel free to notify me.
