# BookingProject


This project is written with C# language and using ASP.NET Core and EntityFramework Core.
This project was written with a layered architectural understanding.(Which is 4 layers Entities-DataAccessLayer-Business Logic-WebAPI)

In this project   https://uibakery.io/sql-playground used as a database so it is a Database-First EntityFramework approach project.In order to implement this db to the Entity Layer we need these packages to be installed in this layer.
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.Tools
* Microsoft.NETCore.App
* Npgsql.EntityFrameworkCore.PostgreSQL.Design

And then from package console manager we need to write this command in order to get db tables version of entity classes.

* Scaffold-DbContext "Host=hostname;Database=databasename;Username=username;Password=password" Npgsql.EntityFrameworkCore.PostgreSQL -o Models



## Prerequirements

* Visual Studio 2022
* .NET Core 6 SDK
* For DB: Postgre Sql 

## How To Run

* Open solution in Visual Studio 2022
* Set WebApı project as Startup Project and build the project.
* Run the application.

## Swagger 
![12](https://user-images.githubusercontent.com/77547891/190441907-c532e023-9ca2-42ea-8dc3-c2c156a493e8.png)

booking/search

![3](https://user-images.githubusercontent.com/77547891/190441962-d2fa11b0-5206-4cbe-a6b6-1f56b932ecac.PNG)
![4](https://user-images.githubusercontent.com/77547891/190441967-0791ef25-3a2b-4e2e-bce5-8a670d505560.PNG)



The Problem:There isn't any primary keys in table since it's a predesigned db couldn't change it coded the project according to this.
*Layered architecture; it was the development of a project accompanied by basically standardized sections /layers / parts within the framework of certain principles in order to be more conveniently managed and developed in a hierarchical manner
