# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

# Copy project files
COPY ["src/CommerceAI.Api/CommerceAI.Api.csproj", "src/CommerceAI.Api/"]
COPY ["src/CommerceAI.Application/CommerceAI.Application.csproj", "src/CommerceAI.Application/"]
COPY ["src/CommerceAI.Domain/CommerceAI.Domain.csproj", "src/CommerceAI.Domain/"]
COPY ["src/CommerceAI.Infrastructure/CommerceAI.Infrastructure.csproj", "src/CommerceAI.Infrastructure/"]
COPY ["src/CommerceAI.AI/CommerceAI.AI.csproj", "src/CommerceAI.AI/"]

# Restore dependencies
RUN dotnet restore "src/CommerceAI.Api/CommerceAI.Api.csproj"

# Copy source
COPY . .

# Build
WORKDIR "/src/src/CommerceAI.Api"
RUN dotnet build "CommerceAI.Api.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish

RUN dotnet publish "CommerceAI.Api.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=publish /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:${PORT}

ENTRYPOINT ["dotnet", "CommerceAI.Api.dll"]