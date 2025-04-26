# PRCR 1.0 - National Parks Management System of Costa Rica

This project aims to develop an information system for managing national parks and biological reserves in Costa Rica. The system allows the registration of visitors, ticket sales, site ratings, and the generation of administrative reports.

## 🛠️ Technologies Used

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- SQL Server
- Razor Pages
- Bootstrap 5

## 📦 System Modules

### 1. Maintenance Module

Supports creating, reading, updating, deleting, and filtering the following data:

- Site Types: National parks, wildlife refuges, or other types defined by the administration.
- National Parks: Name, location, coordinates, area, recognitions, etc.
- Wildlife Refuges: Similar information as parks.
- Species: Type (animal, plant, etc.), common and scientific names, size, weight, characteristics.
- Location: Province, canton, and district for each site.
- Prices: Different rates for weekdays and Sundays.
- Card Commissions: VISA, Mastercard, AmEx, etc.

### 2. Ticketing Module

- Ticket sales for parks and reserves.
- Date selection with dynamic price calculation.
- Automatic registration of transaction commissions.
- Email confirmation sent to the visitor.

### 3. Ratings Module

- Anonymous rating from 1 to 5 stars.
- Comment field for observations.
- Automatic average rating displayed on each site’s profile.

### 4. Reports Module

- Commission reports per card type within a date range (PDF).
- Best and worst-rated parks and reserves report (PDF).

### 5. Visitors Module

- Basic visitor registration: name, ID or passport, country, birthdate, email, reason for visit.
- Country management with continent information.

## 📚 Database

- ORM: Entity Framework Core
- DBMS: SQL Server
- Relational Model: Normalized with appropriate foreign keys and relationships.
- Migrations: Automated via EF Core.
- Includes data dictionary, creation script, and initial data load.

## 🚀 How to Run the Project

1. Clone the repository:

   ```bash
   git clone https://github.com/CristhoferVindas/National-Parks.git
   ```

2. Open the project in Visual Studio 2022 or higher.

3. Configure the connection string in `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=PRCR_DB;Trusted_Connection=True;"
   }
   ```

4. Run the migrations:

   ```bash
   dotnet ef database update
   ```

5. Run the application:
   - Use IIS Express or Kestrel
   - Visit `https://localhost:5001`
