# Stage 1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /build
COPY . .
RUN dotnet restore "AccountDataIngestionService.csproj" --disable-parallel
RUN dotnet publish "AccountDataIngestionService.csproj" -c Release -o /app --no-restore
# Stage 2
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final

ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=”development”

EXPOSE    5000
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "AccountDataIngestionService.dll"]
