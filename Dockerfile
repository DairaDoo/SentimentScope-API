# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar archivos del proyecto
COPY *.sln .
COPY SentimentScopeAPI.csproj .
RUN dotnet restore SentimentScopeAPI.csproj

# Copiar el resto del contenido
COPY . .

# Publicar la aplicación
RUN dotnet publish SentimentScopeAPI.csproj -c Release -o /app/publish

# Etapa 2: Imagen de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copiar archivos publicados
COPY --from=build /app/publish .

# Puerto que expone la aplicación (coincide con el usado en Program.cs)
EXPOSE 8080

# Comando de inicio
ENTRYPOINT ["dotnet", "SentimentScopeAPI.dll"]
