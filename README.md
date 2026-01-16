# StageLab

A monorepo containing a .NET API backend and Next.js frontend.

## Prerequisites

- [Node.js](https://nodejs.org/) (v18+)
- [.NET SDK 10](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/)

## Project Structure

```
apps/
  api/          # .NET 10 Web API
  api-tests/    # API test project
  web/          # Next.js frontend
```

## Getting Started

### 1. Clone and install dependencies

```bash
git clone <repo-url>
cd StageLabApi

# Install Node dependencies
npm install

# Restore .NET tools (husky, csharpier)
dotnet tool restore

# Install git hooks
dotnet husky install
```

### 2. Configure the API

Create user secrets for the API:

```bash
cd apps/api
dotnet user-secrets set "DefaultConnection" "Host=localhost;Database=stagelab;Username=postgres;Password=yourpassword"
dotnet user-secrets set "Jwt:Key" "your-secret-key-at-least-32-characters-long"
dotnet user-secrets set "Jwt:Issuer" "StageLabApi"
dotnet user-secrets set "Jwt:Audience" "StageLabApi"
dotnet user-secrets set "Jwt:ExpiryMinutes" "60"
```

### 3. Set up the database

```bash
cd apps/api
dotnet ef database update
```

### 4. Run the applications

**API (runs on http://localhost:5215):**

```bash
cd apps/api
dotnet run
```

**Web (runs on http://localhost:3000):**

```bash
npx nx dev web
```

Or run both with Nx:

```bash
npx nx run-many -t dev serve -p web api
```

## Development

### Code Formatting

C# code is formatted with CSharpier on commit. To format manually:

```bash
dotnet csharpier format apps/api
```

### Running Tests

```bash
cd apps/api-tests
dotnet test
```

### Creating Migrations

```bash
cd apps/api
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

## Pre-commit Hooks

The repo uses Husky.NET to run pre-commit checks:

1. **Format** - CSharpier formats C# files
2. **Build** - Ensures the API builds without errors

To skip hooks (not recommended):

```bash
git commit --no-verify
```