#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Kla.NumberToWord.Api/Kla.NumberToWord.Api.csproj", "src/Kla.NumberToWord.Api/"]
COPY ["src/Kla.NumberToWord.Application/Kla.NumberToWord.Application.csproj", "src/Kla.NumberToWord.Application/"]
COPY ["src/Kla.NumberToWord.Core/Kla.NumberToWord.Core.csproj", "src/Kla.NumberToWord.Core/"]
RUN dotnet restore "./src/Kla.NumberToWord.Api/Kla.NumberToWord.Api.csproj"
COPY . .
WORKDIR "/src/src/Kla.NumberToWord.Api"
RUN dotnet build "./Kla.NumberToWord.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Kla.NumberToWord.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kla.NumberToWord.Api.dll"]