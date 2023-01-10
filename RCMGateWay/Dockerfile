# Stage 1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /build
COPY . .
RUN dotnet restore "RCMGateWay.csproj" --disable-parallel
RUN dotnet publish "RCMGateWay.csproj" -c Release -o /app --no-restore
# Stage 2
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final

ENV ASPNETCORE_URLS=http://+:5004
ENV ASPNETCORE_ENVIRONMENT=”development”

EXPOSE    5004
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "RCMGateWay.dll"]
