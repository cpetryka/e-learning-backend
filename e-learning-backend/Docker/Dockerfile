FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["e-learning-backend/e-learning-backend.csproj", "e-learning-backend/"]
RUN dotnet restore "e-learning-backend/e-learning-backend.csproj"
COPY . .
WORKDIR "/src/e-learning-backend"
RUN dotnet build "e-learning-backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "e-learning-backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN mkdir -p /app/wwwroot/uploads
ENTRYPOINT ["dotnet", "e-learning-backend.dll"]