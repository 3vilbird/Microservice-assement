FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT=Development 

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["storageservice/storageservice.csproj", "storageservice/"]
RUN dotnet restore "storageservice/storageservice.csproj"
COPY . .
WORKDIR "/src/storageservice"
RUN dotnet build "storageservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "storageservice.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "storageservice.dll"]
