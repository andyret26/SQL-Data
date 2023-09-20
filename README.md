# SQL-DATA
## Description
There is two parts to this repo, First part is SqlScripts and second is SqlClientReading.

SqlScripts: This has various SQL scripts that does CRUD operations and other operations such as making relationships.\
The scripts should be able to run in order without failiour 

SqlClientReading: This is .NET 6 console application with `Microsoft.Data.SqlClient` that does various opperations on a pre existing db.\
The program.cs file in this application will use the opperations and write out relevant info to the console

## Contributions

- [@Philip Thangngat](https://github.com/thangfart)
- [@Anders S. Wiik](https://github.com/andyret26)

## Usage
```cs
git clone git@github.com:andyret26/SQL-Data.git
cd SQL-Data
```

### SqlScripts
Run the `/SqlScripts/AllScripts.sql` in any SQL Software (preferably Sql Server Management Studio)

### SqlClientReader
Run the [/SqlClientReading/Chinook_SqlServer.sql](/SqlClientReading/Chinook_SqlServer.sql) to create the db with seeded data 

In [/SqlClientReading/Repository/ConnectionHelper.cs](/SqlClientReading/Repository/ConnectionHelper.cs)\
replace the DataSource value with your database server name.

Then do the code below
```cs
// in SQL-Data folder
dotnet run --project ./SqlClientReading/SqlClientReading.csproj
```


## Structure
Main file structure

- `SQL-Data/` - Main folder
  - `SqlClientReading/` - Contains the console applications main files
    -  `Models/` - Contain data models that represent database entities
    - `Repository/` - Contains logic and querying for interacting with the DB
  - `SqlScripts/` - Contains sql scripts that preform CRUD operations and more
