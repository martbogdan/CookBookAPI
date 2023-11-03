FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CookBookAPI/CookBookAPI.csproj", "CookBookAPI/"]
RUN dotnet restore "CookBookAPI/CookBookAPI.csproj"
COPY . .
WORKDIR "/src/CookBookAPI"
RUN dotnet build "CookBookAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CookBookAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CookBookAPI.dll"]
