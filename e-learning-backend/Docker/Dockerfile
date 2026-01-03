FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Kopiuj plik projektu
COPY ["e-learning-backend.csproj", "./"]

# Restore zależności
RUN dotnet restore "e-learning-backend.csproj"

# Kopiuj resztę plików
COPY . .

# Build
RUN dotnet build "e-learning-backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "e-learning-backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN mkdir -p /app/wwwroot/uploads
ENTRYPOINT ["dotnet", "e-learning-backend.dll"]