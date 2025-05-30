# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the app and build
COPY . ./
RUN dotnet publish -c Release -o out

# Use a runtime image for the final container
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "MonteringService.dll"]
