# Introduction
This project is to learn the architecture used in enterprise systems with the following concepts

    REST API design
    Entity Framework Core
    Database migrations
    Repository pattern
    Service layer
    DTOs + AutoMapper
    Swagger/OpenAPI
    Dependency Injection
    Validation
    Caching

# Flow
Controller → Service → Repository → EF Core → Database

# Install EF Core Packages
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools

# Install Swagger
dotnet add package Swashbuckle.AspNetCore

# SQLite DB creation/migration instructions
dotnet ef migrations add InitialCreate
dotnet ef database update

# Install AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection


