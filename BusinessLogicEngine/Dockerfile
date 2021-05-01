#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["BusinessLogicEngine/BusinessLogicEngine.csproj", "BusinessLogicEngine/"]
RUN dotnet restore "BusinessLogicEngine/BusinessLogicEngine.csproj"
COPY . .
WORKDIR "/src/BusinessLogicEngine"
RUN dotnet build "BusinessLogicEngine.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BusinessLogicEngine.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BusinessLogicEngine.dll"]