﻿FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ConsoleAsync/ConsoleAsync.csproj", "ConsoleAsync/"]
RUN dotnet restore "ConsoleAsync/ConsoleAsync.csproj"
COPY . .
WORKDIR "/src/ConsoleAsync"
RUN dotnet build "ConsoleAsync.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsoleAsync.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleAsync.dll"]
