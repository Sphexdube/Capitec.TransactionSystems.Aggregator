# Capitec TransactionSystems Aggregator

A system that aggregates customer financial transaction data from multiple mock data sources and categorizes transactions.

## Overview

This system pulls transaction data from various financial sources (banks, credit cards, payment apps) and provides APIs for retrieving aggregated and categorized transaction information.

The TransactionSystems Aggregator is designed to give customers a comprehensive view of their financial transactions across multiple accounts and payment methods in one unified platform.

## Features

- **Multi-source transaction aggregation** - Consolidate transactions from multiple banks, credit cards, and payment applications
- **Automatic transaction categorization** - Intelligent categorization of transactions (groceries, fuel, dining, etc.)
- **Comprehensive REST API** - Well-documented API endpoints for all transaction operations
- **Real-time transaction sync** - Regular synchronization with connected data sources
- **Spending analytics** - Detailed spending summaries and breakdowns by category
- **Flexible filtering** - Filter transactions by date range, category, and more

## Architecture

The system follows Clean Architecture principles with clear separation of concerns:

- **Presentation Layer** - ASP.NET Core 9.0 Web API with Swagger documentation
- **Application Layer** - Business logic, handlers, validators, and DTOs
- **Domain Layer** - Core entities, domain models, commands, and repository interfaces
- **Infrastructure Layer** - Data persistence, caching, and external data source integrations

### Key Architectural Patterns

- **Repository Pattern** - Abstract data access logic
- **Unit of Work** - Manage database transactions
- **Domain-Driven Design** - Rich domain models with encapsulated business logic
- **CQRS** - Separate read and write operations

## Technology Stack

- **.NET 9.0** - Latest .NET framework
- **ASP.NET Core 9.0** - Web API framework
- **Entity Framework Core 9.0** - ORM for data access
- **SQL Server** - Primary database
- **Swagger/OpenAPI** - API documentation
- **Serilog** - Structured logging
- **Health Checks** - Application health monitoring

## API Endpoints

### Transactions

- `GET /api/v1/transactions/customer/{customerId}` - Get all transactions for a customer
  - Query parameters: `startDate`, `endDate`, `category`
- `GET /api/v1/transactions/{transactionId}` - Get transaction details by ID
- `GET /api/v1/transactions/customer/{customerId}/by-category` - Get transactions grouped by category
- `GET /api/v1/transactions/customer/{customerId}/summary` - Get spending summary with category breakdown

### Categories

- `GET /api/v1/categories` - Get all transaction categories
- `GET /api/v1/categories/{categoryId}` - Get category details by ID

### Data Sources

- `GET /api/v1/datasources` - Get all available data sources
- `GET /api/v1/datasources/customer/{customerId}/connected` - Get customer's connected data sources

## Getting Started

### Prerequisites

- .NET 9.0 SDK or later
- SQL Server (LocalDB, Express, or Full)
- Visual Studio 2022 or Visual Studio Code (optional)

### Installation

1. Clone the repository
2. Restore dependencies:
   ```bash
   dotnet restore
   ```
3. Update database connection string in `appsettings.json` if needed
4. Build the solution:
   ```bash
   dotnet build
   ```

### Running the Application

1. Run the API:
   ```bash
   dotnet run --project src/TransactionSystems.Aggregator.Api
   ```

2. Navigate to the Swagger UI at `http://localhost:5000/swagger` or `https://localhost:5001/swagger`

3. Explore the API endpoints using the interactive Swagger documentation

### Running Tests

```bash
dotnet test
```

## Sample Data

The `/sample` folder contains sample transaction data from different data sources:

- **capitec-bank-transactions.json** - Capitec Bank account transactions
- **standard-bank-creditcard-transactions.json** - Standard Bank credit card transactions
- **snapscan-transactions.json** - SnapScan mobile payment transactions

These files demonstrate the structure of transaction data from various sources and can be used for testing and development.

## Project Structure

```
src/
├── TransactionSystems.Aggregator.Api/                    # Web API project
│   ├── Controllers/V1/                                   # API controllers
│   ├── Middleware/                                        # Custom middleware
│   └── Program.cs                                         # Application entry point
├── TransactionSystems.Aggregator.Application.BackgroundJobs/  # Background job processing
├── TransactionSystems.Aggregator.Application.Constants/  # Application constants
├── TransactionSystems.Aggregator.Application.Events/     # Event definitions
├── TransactionSystems.Aggregator.Application.Handlers/   # Business logic handlers
├── TransactionSystems.Aggregator.Application.HealthCheck/ # Health check implementations
├── TransactionSystems.Aggregator.Application.Models/     # DTOs and view models
├── TransactionSystems.Aggregator.Application.Validators/ # Input validation
├── TransactionSystems.Aggregator.Domain.Commands/        # Command objects
├── TransactionSystems.Aggregator.Domain.Entities/        # Domain entities
├── TransactionSystems.Aggregator.Domain.Interfaces/      # Domain interfaces
├── TransactionSystems.Aggregator.Domain.Models/          # Domain models
├── TransactionSystems.Aggregator.Domain.Observability/   # Logging and monitoring
├── TransactionSystems.Aggregator.Domain.Repository/      # Repository interfaces
├── TransactionSystems.Aggregator.Domain.UnitOfWork/      # Unit of work pattern
├── TransactionSystems.Aggregator.Infrastructure.Cache/   # Caching implementation
├── TransactionSystems.Aggregator.Infrastructure.DataSources/ # Data source integrations
├── TransactionSystems.Aggregator.Infrastructure.Persistence/ # Database context and repositories
└── TransactionSystems.Aggregator.Infrastructure.StoredProcedures/ # Stored procedure wrappers
```

## Configuration

The application uses hierarchical configuration with the following files:

- `appsettings.json` - Base configuration
- `appsettings.Localhost.json` - Local development settings
- `appsettings.Test.json` - Test environment settings
- `appsettings.Production.json` - Production settings

## Health Checks

Health check endpoints are available at:

- `/health` - Basic health check
- `/health/ui` - Health check UI dashboard

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is proprietary software owned by The Capitec.

## Support

For support and questions, please contact the development team.

**Copyright © 2025 Capitec**
