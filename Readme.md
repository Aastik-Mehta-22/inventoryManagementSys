# Inventory Management System

A full-stack, decoupled inventory management application consisting of an **ASP.NET Core Web API** backend connected to an **SQLite** database, and a **.NET C# WPF Desktop Client** application.


---

## 1. Project Definition

The **Inventory Management System** manages product inventory, stock levels, and pricing. The architecture separates concerns between data storage, business logic, and presentation:

1. **Backend Web API:** Built with ASP.NET Core and Entity Framework Core (EF Core). It exposes RESTful HTTP endpoints for full CRUD operations and persists data into an embedded SQLite database (`inventory.db`).
2. **Frontend Desktop Client:** A .NET C# WPF (Windows Presentation Foundation) desktop application that consumes the API endpoints via asynchronous HTTP requests (`HttpClient`), giving users a graphical interface to interact with stock records.

---

## 2. Tech Stack

### Core Technologies
* **Programming Language:** C# (.NET 8)
* **Backend Framework:** ASP.NET Core Web API
* **Database Engine:** SQLite 
* **Frontend UI Framework:** Windows Presentation Foundation (WPF) / .NET C# Desktop
* **API Testing & Verification:** Postman

---

## 3. System Architecture & Data Flow

### Architecture Diagram

```text
  ┌─────────────────────────────────┐
  │   Desktop Client Application    │
  │        (.NET C# WPF UI)         │
  └────────────────┬────────────────┘
                   │
                   │ 1. Sends HTTP Requests (JSON Payload)
                   ▼
  ┌─────────────────────────────────┐
  │   ASP.NET Core Web API Server   │
  │     (Kestrel on Port 5000)      │
  └────────────────┬────────────────┘
                   │
                   │ 2. Routing Engine maps request to InventoryController
                   │ 3. DI Container injects AppDbContext per scope
                   ▼
  ┌─────────────────────────────────┐
  │     Entity Framework Core       │
  │        (Change Tracker)         │
  └────────────────┬────────────────┘
                   │
                   │ 4. Translates C# operations to SQL queries
                   ▼
  ┌─────────────────────────────────┐
  │    SQLite Embedded Database     │
  │         (inventory.db)          │
  └─────────────────────────────────┘

