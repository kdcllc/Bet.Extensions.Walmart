#------------------------------------------------------------------------------------------------------------------------
#
# USAGE:        This Dockerfile builds the sample for hosting application inside of Kubernetes Cluster.
#
# NOTE:         Please run commands from root of the solution.
#
# BUILD:        docker build --rm -f "Bet.Extensions.Walmart.Worker/Dockerfile" -t app:Bet.Extensions.Walmart.Worker .
#
#
# NOTE:        See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#------------------------------------------------------------------------------------------------------------------------

FROM mcr.microsoft.com/dotnet/runtime:6.0-bullseye-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src
COPY ["Bet.Extensions.Walmart.Worker/Bet.Extensions.Walmart.Worker.csproj", "Bet.Extensions.Walmart.Worker/"]
RUN dotnet restore "Bet.Extensions.Walmart.Worker/Bet.Extensions.Walmart.Worker.csproj"
COPY . .
WORKDIR "/src/Bet.Extensions.Walmart.Worker"
RUN dotnet build "Bet.Extensions.Walmart.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bet.Extensions.Walmart.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bet.Extensions.Walmart.Worker.dll"]
