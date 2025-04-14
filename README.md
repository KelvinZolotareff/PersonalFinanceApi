# Personal Finance Control API

This REST API is built using .NET 6, Clean Architecture, Entity Framework Core, and XUnit for tests.  
It manages Users, Accounts, Transactions, Categories, and Financial Goals – essential components for a personal finance control system that can feed dashboards and reports.

## Features

- CRUD operations for Users, Accounts, Transactions, Categories, and Financial Goals.
- Automatic balance update when transactions are processed.
- Soft delete for critical entities.
- Endpoints for aggregated data (Dashboard).
- PostgreSQL support (configurable for SQL Server).
- Containerized with Docker and docker-compose.
- Examples of CI/CD and DevOps practices (ready for pipeline integration).

## Project Structure

