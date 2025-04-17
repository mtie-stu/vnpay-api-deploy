# 🌟 Bước 1: Build app bằng SDK .NET 8.0
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore PDP104/PDP104.csproj
RUN dotnet publish PDP104/PDP104.csproj -c Release -o /app/publish

# 🌟 Bước 2: Tạo runtime container với ASP.NET 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PDP104.dll"]
