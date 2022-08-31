# BookingProject


This project is written with C# language and using ASP.NET Core and EntityFramework Core.
This project was written with a layered architectural understanding.(Which is 4 layers Entities-DataAccessLayer-Business Logic-WebAPI)

In this project   https://uibakery.io/sql-playground used as a database so it is a Database-First EntityFramework approach project.In order to implement this db to the Entity Layer we need these packages to be installed in this layer.
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.Tools
* Microsoft.NETCore.App
* Npgsql.EntityFrameworkCore.PostgreSQL.Design

And then from package console manager we need to write this command in order to get db tables version of entity classes.

* Scaffold-DbContext "Host=psql-mock-database-cloud.postgres.database.azure.com;Database=booking1661538931410oilduxjtefmbtrtw;Username=xwwzlphatkrjstcjmzijpjny@psql-mock-database-cloud;Password=xvowrtzabjyowgmtwocwzfrd" Npgsql.EntityFrameworkCore.PostgreSQL -o Models



## Prerequirements

* Visual Studio 2022
* .NET Core 6 SDK
* For DB: Postgre Sql 

## How To Run

* Open solution in Visual Studio 2022
* Set WebApı project as Startup Project and build the project.
* Run the application.

## Swagger 

![1](https://user-images.githubusercontent.com/77547891/187552724-cae61cb7-fb7c-45c3-9a5c-30e1715e0e3e.PNG)
![2](https://user-images.githubusercontent.com/77547891/187552753-48cce640-d875-4844-8db9-6ecbb0e86644.PNG)
booking/search
![3](https://user-images.githubusercontent.com/77547891/187679752-b8cb05ef-ae42-4c40-b005-803479bceb47.PNG)
![4](https://user-images.githubusercontent.com/77547891/187679729-866c7602-33fc-43a8-944d-3c6f12e79615.PNG)





*Layered architecture; it was the development of a project accompanied by basically standardized sections /layers / parts within the framework of certain principles in order to be more conveniently managed and developed in a hierarchical manner
