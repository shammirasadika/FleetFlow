# FleetFlow
logistics and fleet management system for delivery companies.

## Database Configuration

FleetFlow uses **EF Core** with the **SQL Server** provider (`Microsoft.EntityFrameworkCore.SqlServer`)
for both local development and cloud deployment. The same `ConnectionStrings:FleetFlow`
configuration key is used everywhere — only the connection string value changes between
environments, and no application or EF Core code needs to change.

Connection resiliency (`EnableRetryOnFailure`) is enabled so transient network issues against a
remote database (e.g. Azure SQL) are retried automatically.

The real connection string is **never** stored in `appsettings.json` — it is kept empty there and
supplied locally via .NET User Secrets (or `ConnectionStrings__FleetFlow` in deployed
environments).

### Azure SQL Database (current development approach)

Local development currently connects directly to an Azure SQL Database. Store the connection
string via User Secrets — it is never written to `appsettings.json`, `.env`, or committed to Git:

```powershell
dotnet user-secrets set "ConnectionStrings:FleetFlow" "YOUR_AZURE_SQL_CONNECTION_STRING" --project src/backend/FleetFlow.Api
```

Confirm it was stored:

```powershell
dotnet user-secrets list --project src/backend/FleetFlow.Api
```

Apply EF Core migrations against the configured database:

```powershell
dotnet ef database update --project src/backend/FleetFlow.Api
```

In production/CI this connection string is supplied as the environment variable
`ConnectionStrings__FleetFlow` rather than user secrets.

**No Azure SQL password should ever be committed to Git.**

### Local SQL Server (optional, via Docker)

`.env` is used only for Docker/local container configuration (e.g. `MSSQL_SA_PASSWORD`), never for
the API's connection string.

1. Copy `.env.example` to `.env` and set a strong `MSSQL_SA_PASSWORD` (never commit `.env`).
2. Start SQL Server in Docker:

   ```powershell
   docker compose up -d
   ```

3. Configure the connection string via .NET User Secrets:

   ```powershell
   dotnet user-secrets set "ConnectionStrings:FleetFlow" "Server=localhost,1433;Database=FleetFlow;User Id=sa;Password=<local-development-password>;Encrypt=False;TrustServerCertificate=True;" --project src/backend/FleetFlow.Api
   ```

4. Apply EF Core migrations:

   ```powershell
   dotnet ef database update --project src/backend/FleetFlow.Api
   ```

