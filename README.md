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
ADD HERE LATER

in [/SqlClientReading/Repository/ConnectionHelper.cs](/SqlClientReading/Repository/ConnectionHelper.cs)\
replace the DataSource value with your database server name.\
and 
```cs
// in SQL-Data folder
dotnet run --project ./SqlClientReading/SqlClientReading.csproj
```


## Structure

CHANGE THIS TO \
Main file structure

- `SQL-Data/` - Main folder
  - `SQLsub/` - Contains the main application code
    -  `SQLsub1/` - Contains C# classes
       - `SQLsub2/` - Different types of hero classes (Wizard, Archer, etc..)
    - `SQLsub1/` - Contains C# enums
  - `SQLsub/` - Tests folder
