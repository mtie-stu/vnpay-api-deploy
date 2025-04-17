# Sử dụng SDK .NET 8.0 để build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj và restore
COPY *.csproj ./
RUN dotnet restore

# Copy toàn bộ project và build
COPY . ./
RUN dotnet publish -c Release -o out

# Runtime để chạy app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Lệnh chạy app
ENTRYPOINT ["dotnet", "PDP104.dll"]
