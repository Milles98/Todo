# TodoApp

A simple ASP.NET Core Web API for managing todo items. Built with .NET 8, Entity Framework Core, and a layered architecture.

## Features

- Create, read, update, patch, and delete todos
- RESTful API endpoints
- Entity Framework Core with SQL Server
- DTO-based validation
- Exception handling middleware
- Unit tests with xUnit and FluentAssertions
- Swagger/OpenAPI documentation

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (or use in-memory for testing)

### Setup

1. Clone the repository:
2. Restore dependencies:
3. Apply migrations and update the database:
4. Run the API:
5. Open [Swagger UI](https://localhost:5001/swagger) for API documentation.

### Running Tests

## Project Structure

- `src/TodoApp.Api` - ASP.NET Core Web API
- `src/TodoApp.Application` - Application layer (business logic)
- `src/TodoApp.Domain` - Domain entities
- `src/TodoApp.Infrastructure` - Data access, EF Core, migrations
- `tests/TodoApp.Tests` - Unit tests

## API Endpoints

- `GET /api/todo/getAll` - Get all todos
- `GET /api/todo/getOne?id={id}` - Get a todo by ID
- `POST /api/todo/createTodo` - Create a new todo
- `PUT /api/todo/updateTodo?id={id}` - Update a todo
- `PATCH /api/todo/patchTodo?id={id}` - Patch a todo
- `DELETE /api/todo/deleteTodo?id={id}` - Delete a todo

## Contributing

Pull requests are welcome. For major changes, please open an issue first.

## License

MIT