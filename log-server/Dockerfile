# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /source

COPY --link *.csproj .
RUN dotnet restore

COPY --link . .
RUN dotnet publish --no-restore -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/runtime:10.0
WORKDIR /app

COPY --link --from=build /app .
USER $APP_UID
ENTRYPOINT ["./LogServer"]
