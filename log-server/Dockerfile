FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine

WORKDIR /dotnetapp

COPY . .
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/LogServer.dll"]