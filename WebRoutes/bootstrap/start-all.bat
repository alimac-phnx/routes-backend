@echo-off

docker-compose up --build -d
cd "%~dp0.."
dotnet ef migrations add InitialCreateMigration
dotnet ef database update
dotnet run --project "WebRoutes.csproj"
pause