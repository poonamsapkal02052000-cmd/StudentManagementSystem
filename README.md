# Student Management System API

Student Management System is an ASP.NET Core Web API project developed using Layered Architecture for managing student records securely using JWT Authentication.

---

## Features

- JWT Authentication
- CRUD Operations
- Global Exception Handling Middleware
- Serilog Logging
- Swagger API Documentation
- SQL Server Integration
- Layered Architecture

---

## Technologies Used

- ASP.NET Core Web API (.NET 8)
- SQL Server
- Entity Framework Core
- JWT Authentication
- Swagger
- Serilog

---

## Architecture

```text
Controller → Service → Repository → Database
```

---

## Database Setup

### Create Database

```sql
CREATE DATABASE StudentDB;
```

### Use Database

```sql
USE StudentDB;
```

### Create Students Table

```sql
CREATE TABLE Students
(
    Id INT PRIMARY KEY IDENTITY(1,1),

    Name NVARCHAR(100) NOT NULL,

    Email NVARCHAR(100) NOT NULL,

    Age INT,

    Course NVARCHAR(100),

    CreatedDate DATETIME DEFAULT GETDATE()
);
```

---

## Connection String

Updated connection string in `appsettings.json`

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

## Authentication

### Login API

```http
POST /api/Auth/login
```

### Credentials

| Username | Password |
|---|---|
| admin | admin123 |

---

## API Endpoints

| Method | Endpoint |
|---|---|
| GET | /api/Students |
| GET | /api/Students/{id} |
| POST | /api/Students |
| PUT | /api/Students/{id} |
| DELETE | /api/Students/{id} |

---

## Swagger URL

```text
https://localhost:7276/swagger
```
