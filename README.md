# Banking Application Web API
This project provides a Web API for a banking application, enabling management of customers, accounts, cards, and transactions. It supports core banking functionalities with CRUD operations. The project is developed using **.NET Core**, **Entity Framework Core**, and **PostgreSQL**.

## Features
* CRUD operations for customers, accounts, cards, and transactions
* Activation/deactivation functionalities for customers and accounts
* Card payments and credit limit management
* Account-to-account transfers
* Built-in API documentation with Swagger
* Uses Automapper for DTOs

## Getting Started
This project is built with .NET Core 6 and Entity Framework Core. Follow the steps below to set up and run the project on your local machine.

### Prerequisites
* .NET 6 SDK
* PostgreSQL
* Visual Studio 2022 or later

### Installation

#### 1. Clone the Repository
git clone https://github.com/tekinmuhammed/Web-Api-Project

cd banking-app-api

#### 2. Install Dependencies
Run the following command in the project directory to install the required NuGet packages:

dotnet restore

#### 3. Configure Database Settings
In **appsettings.json** or **appsettings.Development.json**, update the **ConnectionStrings** section with your PostgreSQL database connection string:

"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=bankingappdb;Username=yourusername;Password=yourpassword"
}

#### 4. Create and Apply Migrations to Database
dotnet ef database update

#### 5. Run the Application
dotnet run

#### 6. Access Swagger Interface
Once the application is running, visit **http://localhost:5000/swagger** to view the API documentation.

## API Usage
This project provides API endpoints for main banking functionalities. You can see details and test each endpoint through the Swagger interface.

### Customer Operations
* **GET /api/customers** - Retrieve all customers
* **POST /api/customers** - Create a new customer

### Account Operations
* **GET /api/accounts** - Retrieve all accounts
* **POST /api/accounts** - Create a new account
* **PUT /api/accounts/{id}/deactivate** - Deactivate an account

### Card Operations
* **POST /api/cards** - Create a new card
* **PUT /api/cards/{id}/deactivate** - Deactivate a card

### Transaction Operations
* **POST /api/transactions** - Execute a transaction


## Technologies Used
* **.NET Core** - Application framework
* **Entity Framework Core** - ORM for database management
* **PostgreSQL** - Database management system
* **AutoMapper** - Model-to-DTO data transformations
* **Swashbuckle/Swagger** - API documentation generation
* **Newtonsoft.Json** - JSON serialization and deserialization
