# Inventory Management System

A full-stack, decoupled inventory management application consisting of an **ASP.NET Core Web API** backend connected to an **SQLite** database, and a **.NET C# WPF Desktop Client** application.

---

## 1. Project Definition

The **Inventory Management System** manages product inventory, stock levels, and pricing.

The architecture separates concerns between **data storage**, **business logic**, and **presentation**.

### 1.1 Backend Web API

Built with **ASP.NET Core** and **Entity Framework Core (EF Core)**.

It:

- Exposes RESTful HTTP endpoints.
- Provides full CRUD operations.
- Handles business and data-access logic.
- Persists data into an embedded SQLite database (`inventory.db`).

### 1.2 Frontend Desktop Client

A **.NET C# WPF (Windows Presentation Foundation)** desktop application.

It:

- Provides the graphical user interface.
- Communicates with the Web API using `HttpClient`.
- Uses asynchronous HTTP requests.
- Allows users to view and manage inventory records.

---

## 2. Tech Stack

### Core Technologies

| Component | Technology |
|---|---|
| Programming Language | C# (.NET 8) |
| Backend Framework | ASP.NET Core Web API |
| ORM | Entity Framework Core |
| Database Engine | SQLite |
| Frontend UI Framework | WPF (.NET C# Desktop) |
| HTTP Client | `HttpClient` |
| API Testing | Postman |

---

## 3. System Architecture & Data Flow

### 3.1 Architecture Diagram

```text
  ┌─────────────────────────────────┐
  │   Desktop Client Application    │
  │        (.NET C# WPF UI)         │
  └────────────────┬────────────────┘
                   │
                   │ 1. Sends HTTP Requests
                   │    with JSON Payload
                   ▼
  ┌─────────────────────────────────┐
  │   ASP.NET Core Web API Server   │
  │     (Kestrel on Port 5000)      │
  └────────────────┬────────────────┘
                   │
                   │ 2. Routing maps request
                   │    to InventoryController
                   │
                   │ 3. Dependency Injection
                   │    provides AppDbContext
                   ▼
  ┌─────────────────────────────────┐
  │     Entity Framework Core       │
  │        (Change Tracker)         │
  └────────────────┬────────────────┘
                   │
                   │ 4. Translates C# operations
                   │    into SQL queries
                   ▼
  ┌─────────────────────────────────┐
  │    SQLite Embedded Database     │
  │         (inventory.db)          │
  └─────────────────────────────────┘

```

# 4. Some Why Questions

## Why Choose SQLite?
I chose SQLite because it's an embedded database—it runs in-process with the desktop application and stores all data in a single local .db file without needing an external database server running. It lets me focus on C# data modeling and Entity Framework Core without worrying about network setup, while still using standard SQL under the hood.

## Do I Need to Install Microsoft SQL Server or MySQL?
No

## Can I Directly View inventory.db?
No , Not like a normal .txt, .json, or .csv file.
An SQLite database is stored in a database/binary format.

## Can I View inventory.db in VS Code?
Yes, A SQLite extension can be used in VS Code to inspect the database.


# 5. Recommended Learning Flow
If someone is cloning this project or using it as a way to learn **C#/.NET full-stack development**, the recommended approach is to build and verify the application in stages.

The idea is to **finish and verify the backend first**, then build the frontend on top of the working API.

## Phase 1: Backend Construction & Verification

Initialize the Web API using dotnet new webapi -n InventoryApi.

Implement models, database context, and controllers.

Verify all 5 CRUD operations in Postman.

## Phase 2: Desktop Frontend Construction

Create a WPF application using dotnet new wpf -n InventoryDesktopUI.

Integrate HttpClient to communicate with api (backend).

Bind API data to WPF controls (DataGrid, TextBoxes, Buttons) using data binding and async event handlers