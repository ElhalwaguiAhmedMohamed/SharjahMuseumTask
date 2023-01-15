# SharjahMuseumTask
THe task is to implement a simple employee crud operation and a report for their attendence and to expose an api to do said.
Allowing admins to login with JWT tokens and to create, update, delete and retrieve eomployees.
Allowing admins to get a report a specific employee attendence.
Added unit tests for the controllers.
## Requirements
- Create an employee setup screen and db table to make CRUD operations for “employees” table with columns “EMPID, Name, Email, PhoneNo”, And CRUD operations for
- “EmployeeAttendance” with columns ”EVETLGUID, SRVDT, DEVDT, DEVUID, EMPID”

## System Arcjitecture
- Used a 3 layer clean architecture to implement the solution
- Implemented repository pattern and Inverion of control.
- Implemented unit of work to make it easier dealing with different entities in the system.

![Architecture](https://www.dotnetcurry.com/images/mvc/ASP.NET-MVC-5-Using-a-Simple-Repository-_6AFF/repository-aspnet-mvc.png)


## Authentication & Authorization
- Used JWT scheme to authenticate and authorize

## Technologies
- c# 
- NET 6
- EF 7
- SQL Server
- Angular for front end ---> link to frontend repo (https://github.com/ElhalwaguiAhmedMohamed/SharjahMuseumTaskFrontend.git)

## Tools used for testing 
- Fake it easy
- Xunit
- Fluent Assertions

## How TO RUN
- The application has some migrations to intiate the database you can use the command ```update-database``` to run the migrations and create the database. you will just need to change the connection string
of the database.
- You can also check the provided postman collection provided with the solution
## Auhtor 
[Mohamed Ahmed Elhalwagui](https://github.com/ElhalwaguiAhmedMohamed)