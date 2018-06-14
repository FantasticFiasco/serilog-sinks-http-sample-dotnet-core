FROM microsoft/dotnet:2.1-sdk

WORKDIR /dotnetapp

COPY . .
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/Sample.dll"]