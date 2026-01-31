FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY StageLabApi.csproj ./
RUN dotnet restore "StageLabApi.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "StageLabApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StageLabApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "StageLabApi.dll"]