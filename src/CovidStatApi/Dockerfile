#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CovidStatApi/CovidStatApi.csproj", "CovidStatApi/"]
COPY ["CovidStatApi.Domain/CovidStatApi.Domain.csproj", "CovidStatApi.Domain/"]
COPY ["CovidStatApi.Services/CovidStatApi.Services.csproj", "CovidStatApi.Services/"]
RUN dotnet restore -s https://api.nuget.org/v3/index.json "CovidStatApi/CovidStatApi.csproj"
COPY . .
WORKDIR "/src/CovidStatApi"
RUN dotnet build "CovidStatApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CovidStatApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CovidStatApi.dll"]