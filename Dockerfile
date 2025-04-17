# ========================
# 🚧 STAGE 1: BUILD
# ========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file và project file
COPY PDP104/PDP104.csproj PDP104/
RUN dotnet restore PDP104/PDP104.csproj

# Copy toàn bộ project
COPY . .

# Publish app
RUN dotnet publish PDP104/PDP104.csproj -c Release -o /app/publish

# =========================
# 🚀 STAGE 2: RUNTIME
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy published output từ stage build
COPY --from=build /app/publish .

# Mở cổng (tùy chọn)
EXPOSE 80

# Chạy ứng dụng
ENTRYPOINT ["dotnet", "PDP104.dll"]
