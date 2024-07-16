#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
#external
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AlfaguaraClub.Backend.Api/AlfaguaraClub.Backend.Api.csproj", "AlfaguaraClub.Backend.Api/"]
COPY ["AlfaguaraClub.Backend.Application/AlfaguaraClub.Backend.Application.csproj", "AlfaguaraClub.Backend.Application/"]
COPY ["AlfaguaraClub.Backend.Infraestructure/AlfaguaraClub.Backend.Infraestructure.csproj", "AlfaguaraClub.Backend.Infraestructure/"]
COPY ["AlfaguaraClub.Backend.Domain/AlfaguaraClub.Backend.Domain.csproj", "AlfaguaraClub.Backend.Domain/"]
COPY ["AlfaguaraClub.Backend.Persistence/AlfaguaraClub.Backend.Persistence.csproj", "AlfaguaraClub.Backend.Persistence/"]

RUN dotnet restore "./AlfaguaraClub.Backend.Api/AlfaguaraClub.Backend.Api.csproj"
COPY . .
WORKDIR "/src/AlfaguaraClub.Backend.Api"
RUN dotnet build "./AlfaguaraClub.Backend.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AlfaguaraClub.Backend.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlfaguaraClub.Backend.Api.dll"]