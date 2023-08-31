# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build

COPY src .
RUN dotnet build ./WebApi/WebApi.csproj
RUN dotnet publish ./WebApi/WebApi.csproj -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "WebApi.dll"]