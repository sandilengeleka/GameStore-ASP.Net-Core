# GameStore API

A small ASP.NET Core Web API for managing games and genres. Built with .NET 10 and EF Core using SQLite.

## Features

- CRUD for `Game` entities (Create, Read, Update, Delete)
- Read-only list for `Genre`
- EF Core migrations and automatic seeding of default genres
- Minimal API endpoints

## Tech stack

- .NET 10
- ASP.NET Core Minimal API
- Entity Framework Core with SQLite

## Requirements

- .NET 10 SDK (install from https://dotnet.microsoft.com)

## Quick start

1. Clone the repo:

```bash
git clone <your-repo-url>
cd GameStore
```

2. Configure connection string (optional):

The default SQLite file is configured in `GameStore.Api/appsettings.json` under `ConnectionStrings:GameStore` (`Data Source=GameStore.db`). Change it if you need a different path.

3. Build and run:

```bash
dotnet restore
dotnet build
dotnet run --project GameStore.Api
```

When the app starts it will display the listening URLs in the console. The database migrations are applied automatically on startup and the `Genres` table is seeded if empty.

## API Endpoints

Base route groups:

- `GET /genres` — list genres
- `GET /games` — list games (summary)
- `GET /games/{id}` — get game details
- `POST /games` — create a game
- `PUT /games/{id}` — update a game
- `DELETE /games/{id}` — delete a game

Example requests (replace `http://localhost:PORT` with the URL printed when running):

List genres:

```bash
curl http://localhost:PORT/genres
```

List games:

```bash
curl http://localhost:PORT/games
```

Create a game:

```bash
curl -X POST http://localhost:PORT/games \
  -H "Content-Type: application/json" \
  -d '{"name":"New Game","genreId":1,"price":29.99,"releaseDate":"2025-11-01"}'
```

Update a game:

```bash
curl -X PUT http://localhost:PORT/games/1 \
  -H "Content-Type: application/json" \
  -d '{"name":"Updated Game","genreId":1,"price":19.99,"releaseDate":"2025-11-01"}'
```

Delete a game:

```bash
curl -X DELETE http://localhost:PORT/games/1
```

## Data / Migrations

Migrations are included in `GameStore.Api/Data/Migrations`. On startup the app calls `MigrateDb()` to apply pending EF Core migrations.

If you need to create or update migrations locally you can use the EF Core CLI from the repository root (requires the `dotnet-ef` tool):

```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add <Name> --project GameStore.Api --startup-project GameStore.Api
dotnet ef database update --project GameStore.Api --startup-project GameStore.Api
```

## Development notes

- Endpoints are defined in `GameStore.Api/Endpoints`.
- The database provider (SQLite) and seeding are configured in `GameStore.Api/Data/Migrations/DataExtensions.cs`.

## Contributing

PRs are welcome. Open an issue or PR describing the change.

## License

Specify a license for your project (e.g. MIT) by adding a `LICENSE` file.
