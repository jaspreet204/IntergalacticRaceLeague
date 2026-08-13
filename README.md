# Intergalactic Race League

# Project Description

Intergalactic Race League is an ASP.NET Core MVC application used to manage racers, vehicles and tournaments.
The project uses Entity Framework Core with Code First approach and ASP.NET Core Identity for authentication and authorization.

# Main Features

- Manage Racers
- Manage Vehicles
- Manage Tournaments
- Racers can join Tournaments
- Login and Registration
- Admin and User roles
- Role-based authorization
- Dashboard showing application data

# User Roles

# Admin
Admin can manage tournaments and can manage all racers and vehicles.

# User
Users can create and edit their own racers and vehicles and join tournaments.

# Test Accounts
Admin:
Email: admin@raceleague.com  
Password: Admin123!

User:
Email: user@raceleague.com  
Password: User123!

# Technologies Used
- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- HTML
- CSS
- Bootstrap

# Database
The application uses Code First migrations.

Main tables:
- Racers
- Vehicles
- Tournaments
- RacerTournaments
- Identity tables

# Relationships

- One Vehicle can have many Racers.
- One Racer belongs to one Vehicle.
- Racers and Tournaments have a many-to-many relationship through RacerTournament.

## Delete Rules

A Vehicle cannot be deleted if it is currently assigned to a Racer.
A Racer cannot be deleted if the Racer is currently connected to a Tournament.
The related record must be removed first before deleting the Vehicle or Racer.
