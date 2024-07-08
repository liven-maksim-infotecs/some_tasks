# Base layer
FROM mcr.microsoft.com/dotnet/aspnet:6.0.31-bookworm-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN apt update \
    && apt install -y \
            curl \
    && rm -rf /var/lib/apt/lists/*


# Building layer
FROM mcr.microsoft.com/dotnet/sdk:6.0.423-1-bookworm-slim AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_18.x | bash - \
    && apt install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["Monitoring/Monitoring.csproj", "Monitoring/"]
RUN dotnet restore "Monitoring/Monitoring.csproj" --nologo
COPY . .
WORKDIR "/src/Monitoring"
RUN dotnet build "Monitoring.csproj" --no-restore --nologo -c Release


# Publish layer
FROM build AS publish
RUN dotnet publish "Monitoring.csproj" --no-build --nologo -c Release -o /app/publish /p:UseAppHost=false

# Runtime layer
FROM base AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Monitoring.dll"]
