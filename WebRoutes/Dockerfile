FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["WebRoutes/WebRoutes.csproj", "WebRoutes/"]
RUN dotnet restore "WebRoutes/WebRoutes.csproj"

# Установим EF CLI
RUN dotnet tool install --global dotnet-ef --version 9.*
ENV PATH="$PATH:/root/.dotnet/tools"

COPY . .
WORKDIR "/src/WebRoutes"
RUN dotnet build "WebRoutes.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Сначала создаём миграции (если их нет)
RUN dotnet ef migrations add Initial --no-build || echo "Migration already exists"

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WebRoutes.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

# EF tools тоже нужны в рантайме для миграции
RUN dotnet tool install --global dotnet-ef --version 9.*
ENV PATH="$PATH:/root/.dotnet/tools"

# Применить миграции при запуске
ENTRYPOINT ["sh", "-c", "dotnet ef database update --no-build && dotnet WebRoutes.dll"]
