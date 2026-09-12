# latiendahn

Aplicacion full-stack: backend en .NET 10 (monolito modular) y frontend en Angular 22
(standalone, zoneless, signals), con PostgreSQL como base de datos.

## Estructura

- `backend/`  — solucion .slnx, BuildingBlocks, host Api, modulo `Sample`, tests.
- `frontend/` — workspace Angular (app + libreria `shared` via alias `@app/*`), feature `Sample`.
- `docker-compose.yml` — Postgres 17 para desarrollo.

## Puesta en marcha

1. Infra: `docker compose up -d postgres`
2. Migracion inicial del modulo Sample:
   ```
   dotnet tool install --global dotnet-ef
   dotnet ef migrations add InitialSample \
     --project backend/src/Modules/Sample/latiendahn.Modules.Sample \
     --startup-project backend/src/Api/latiendahn.Api
   dotnet ef database update \
     --project backend/src/Modules/Sample/latiendahn.Modules.Sample \
     --startup-project backend/src/Api/latiendahn.Api
   ```
3. API: `dotnet run --project backend/src/Api/latiendahn.Api`  →  http://localhost:5080
4. Frontend: `cd frontend && pnpm install && pnpm start`  →  http://localhost:4200

## Git hooks (Husky.NET)

El pre-commit corre `dotnet format` sobre los `.cs` staged y `pnpm lint` en el frontend.
Si clonas el repo en otra maquina, activalo con: `dotnet tool restore && dotnet husky install`.

## Como agregar un modulo nuevo

Clona la carpeta `backend/src/Modules/Sample/` con el nombre del modulo, renombra namespaces,
registralo en `backend/src/Api/latiendahn.Api/Program.cs` con `.Add(new TuModulo())`, y anade su
proyecto al `.slnx`. Los modulos solo se comunican por `Contracts/` y eventos, nunca por sus internals.