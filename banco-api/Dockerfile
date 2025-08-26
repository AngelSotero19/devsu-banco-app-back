# ========= Build =========
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1) Copiamos el csproj y restauramos
COPY *.csproj ./
RUN dotnet restore

# 2) Copiamos todo el código y publicamos
COPY . .
RUN dotnet publish -c Release -o /out /p:UseAppHost=false

# ========= Runtime =========
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# HTTPS (dev)
ENV ASPNETCORE_URLS="https://+:7094;http://+:8080"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path="/https/aspnetapp.pfx"
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="Pass@word1"

# Publicado
COPY --from=build /out ./

EXPOSE 7094 8080

# Si tu proyecto se llama distinto, cambia el nombre del dll
ENTRYPOINT ["dotnet", "banco-api.dll"]