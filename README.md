# Choir Manager

1. [Introduction](#introduction) 
2. [Project structure](#project-structure)
3. [Technologies and packages](#technologies-and-packages-used)
4. [Author](#author)

## Introduction

ChoirManager is a project of mine, that I am making for managing choirs. As a member of one I've seen a lot of 
situations, that require a proper solution, such as sharing the notes, planning events. For the choir leader it is
essential to know in time who is coming on an event and who is not, who is yet to decide, how many singers in a certain
register is attending? On the other hand, if there are many songs and many different versions for a song, which one is
the choir going to sing in an event or in training session? Where are the different events located? I have been
planning this web application to answer to these and many more questions.

My main point in this is to learn more ASP.NET Core on the backend and Typescript / React.js on the frontend. The main
focus is to deepen my skills. The second priority is to make a useful tool for the choir. My goal is to make the first
version of a working program during this spring season (2024) but the schedule for the whole application with all
intended features is open.

In the first working version I have planned to make it possible a user to join a choir and for a choir leader to invite
new members. Soon after that there will be events and music sheets that can be saved in the application.

## Project structure

ChoirManager implements clean project architecture. There are four actual layers in this project:
1. ChoirManager.WebApi
2. ChoirManager.Controllers
3. ChoirManager.Business
4. ChoirManager.Core

There also is a test project, ChoirManager.Test, that I do not count as part of the actual project.

Following clean architecture, the entry point for the program is in WebApi layer. Repository code is also there.
Controller layer only consists of controllers and authorization. Authorization schema in itself is located in WebApi.
Business layer holds all the actual business logic of the program. It uses AutoMapper to convert entities gotten from
the database to convert them into DTOs. Core layer only holds some abstractions and the core entities, no logic at all.

## Technologies and packages used

ChoirManager is written in __C#__ using __ASP.NET Core__ framework. Tests are written using __xUnit__ test framework.

### So far, the packages used are as follows:

WebApi layer:
* Entity Framework Core, v. 7.0.13
* EntityFrameworkCore.NamingConventions
* EFCore.NamingConventions v. 7.0.2
* Microsoft.EntityFrameworkCore.Design v. 7.0.13
* AutoMapper.Extensions.Microsoft.DependencyInjection v. 12.0.1
* Npgsql.EntityFrameworkCore.PostgreSQL v. 7.0.11
* Swashbuckle.AspNetCore v. 6.5.0

Business layer:
* Automapper v. 12.0.1

## Author

This code is fully written by me, Juho Simojoki.