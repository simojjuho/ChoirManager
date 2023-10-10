FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ChorManager.WebApi/ChorManager.WebApi.csproj", "ChorManager.WebApi/"]
RUN dotnet restore "ChorManager.WebApi/ChorManager.WebApi.csproj"
COPY . .
WORKDIR "/src/ChorManager.WebApi"
RUN dotnet build "ChorManager.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChorManager.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChorManager.WebApi.dll"]
