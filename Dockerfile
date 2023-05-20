FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY WebApplication/WebApplication.csproj WebApplication/

RUN dotnet restore WebApplication/WebApplication.csproj

COPY . ./
RUN dotnet publish WebApplication -c Release -o out
 
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "WebApplication.dll"]