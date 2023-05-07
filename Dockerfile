FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GagarinWebAPI/GagarinWebAPI.csproj", "GagarinWebAPI/"]
COPY ["DataAccess.Implementation/DataAccess.Implementation.csproj", "DataAccess.Implementation/"]
COPY ["DataAccess.Interfaces/DataAccess.Interfaces.csproj", "DataAccess.Interfaces/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["UseCases/UseCases.csproj", "UseCases/"]
COPY ["WeatherProvider.Interfaces/WeatherProvider.Interfaces.csproj", "WeatherProvider.Interfaces/"]
COPY ["WeatherProvider.Implementation/WeatherProvider.Implementation.csproj", "WeatherProvider.Implementation/"]
RUN dotnet restore "GagarinWebAPI/GagarinWebAPI.csproj"
COPY . .
WORKDIR "/src/GagarinWebAPI"
RUN dotnet build "GagarinWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GagarinWebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GagarinWebAPI.dll","--environment=Development"]
# ENTRYPOINT ["dotnet", "GagarinWebAPI.dll"]