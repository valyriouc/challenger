# Challenger

Social challenges platform built with ASP.NET Core. Users create challenges for followers/friends; participants join and submit proofs to complete them.

## Features

- Create, browse, and search public or invite-only challenges
- Join challenges, submit proofs (text/image/link), comment, react
- Follows, feeds, and notifications (optional real-time via SignalR)
- User profiles, privacy controls, and reporting
- Moderation: flagging and basic abuse prevention hooks
- JWT authentication with ASP.NET Core Identity
- EF Core data access and migrations

## Tech stack

- .NET 8, ASP.NET Core Web API (or MVC)
- EF Core (SQL Server or SQLite)
- ASP.NET Core Identity + JWT
- SignalR (optional) for real-time updates
- Serilog (optional) for logging

## Quick start

Prerequisites:
- .NET SDK 8.0+
- SQL Server (LocalDB) or SQLite
- Node.js only if a separate SPA client is added

1) Clone and enter the project
- cd src/challenger

2) Configure appsettings.Development.json
```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ChallengerDb;Trusted_Connection=True;MultipleActiveResultSets=true"
        // Or: "DefaultConnection": "Data Source=challenger.db"
    },
    "Jwt": {
        "Issuer": "Challenger",
        "Audience": "Challenger",
        "Key": "dev-only-change-this-super-secret-key"
    },
    "Storage": {
        "Provider": "Local",
        "LocalPath": "wwwroot/uploads"
    },
    "Logging": {
        "LogLevel": { "Default": "Information" }
    }
}
```

3) Restore, migrate, run
```bash
dotnet restore
dotnet tool install -g dotnet-ef # if not installed
dotnet ef database update
dotnet run
```

Default URLs:
- http://localhost:5000
- https://localhost:7000

## Common commands

- Add migration: dotnet ef migrations add InitialCreate
- Update DB: dotnet ef database update
- Run tests: dotnet test

## API (preview)

- Auth
    - POST /api/auth/register
    - POST /api/auth/login
- Profiles
    - GET /api/users/{id}
    - GET /api/users/me
- Challenges
    - GET /api/challenges
    - POST /api/challenges
    - GET /api/challenges/{id}
    - POST /api/challenges/{id}/join
- Submissions
    - POST /api/challenges/{id}/submissions
    - GET /api/challenges/{id}/submissions
    - POST /api/submissions/{id}/reactions
    - POST /api/submissions/{id}/comments
- Follows
    - POST /api/users/{id}/follow
    - DELETE /api/users/{id}/follow
- Notifications
    - GET /api/notifications
    - GET /hubs/notifications (SignalR)

OpenAPI/Swagger is available at /swagger when running in Development.

## Data model (core)

- User: Identity user profile
- Challenge: Title, description, rules, visibility, ownerId, start/end
- Membership: User joined a challenge
- Submission: User’s proof for a challenge
- Reaction: Like/upvote on a submission
- Comment: Threaded discussion on submissions
- Follow: User-to-user follow relationship
- Notification: Event delivery to users
- Report: Abuse report entity

## Project layout

- Program.cs, appsettings*.json
- Controllers/ or Minimal API endpoints
- Domain/Entities, Domain/Events
- Application/Services, DTOs
- Infrastructure/Persistence (EF Core), Identity, Storage
- Web/Filters, Middleware, Hubs
- Tests/

## Configuration notes

- Set ASPNETCORE_ENVIRONMENT=Development for local runs
- For SQLite: update DefaultConnection and add UseSqlite in DbContext configuration
- For image uploads, ensure writable Storage.LocalPath or configure a cloud provider

## Security

- Store a strong Jwt:Key in production secrets
- Enforce max upload sizes and file type checks
- Rate-limit auth and write endpoints
- Implement moderation workflows for reports

## Roadmap

- Challenge templates and recurring schedules
- Team challenges and co-hosts
- Rich media processing and CDN integration
- Advanced leaderboards and scoring rules
- Mobile push notifications

## Contributing

- Open issues for bugs/features
- Use feature branches and small PRs
- Include tests for new behavior
