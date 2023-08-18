#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Tickets.API/Tickets.API.csproj", "Tickets.API/"]
RUN dotnet restore "Tickets.API/Tickets.API.csproj"
COPY . .
WORKDIR "/src/Tickets.API"
RUN dotnet build "Tickets.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tickets.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tickets.API.dll"]