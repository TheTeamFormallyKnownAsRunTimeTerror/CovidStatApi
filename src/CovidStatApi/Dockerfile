FROM mcr.microsoft.com/dotnet/core/sdk:3.1

EXPOSE 80
EXPOSE 5000
EXPOSE 5001 

WORKDIR /app
COPY bin/Debug/netcoreapp3.1 .

ENTRYPOINT ["dotnet", "/app/CovidStatApi.dll"]