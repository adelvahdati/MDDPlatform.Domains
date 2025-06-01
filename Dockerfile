FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app

COPY  MDDPlatform.Domains.Api/app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "MDDPlatform.Domains.Api.dll"]