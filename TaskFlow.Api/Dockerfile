﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TaskFlow.Api/TaskFlow.Api.csproj", "TaskFlow.Api/"]
COPY ["TaskFlow.Domain/TaskFlow.Domain.csproj", "TaskFlow.Domain/"]
COPY ["TaskFlow.Application/TaskFlow.Application.csproj", "TaskFlow.Application/"]
COPY ["TaskFlow.Interfaces/TaskFlow.Interfaces.csproj", "TaskFlow.Interfaces/"]

RUN dotnet restore "TaskFlow.Api/TaskFlow.Api.csproj"
COPY . .
WORKDIR "/src/TaskFlow.Api"
RUN dotnet build "TaskFlow.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TaskFlow.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskFlow.Api.dll"]
