FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApi/WebApi.csproj", "WebApi/"]
RUN dotnet restore "./WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "./WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY jcg /usr/app/jcg
RUN chmod +x /usr/app/jcg

# Switch to root user to install libraries
USER root
RUN apt-get update && \
    apt-get install -y libxml2-dev openssl libxmlsec1-dev libxmlsec1-openssl && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

EXPOSE 8080

CMD ["/usr/app/jcg", "--licenseKey", "n9B5-Km7g-Pp69-j9FE-e9A5", "--runtime", "netcore", "--modules", "WebApi.dll"]