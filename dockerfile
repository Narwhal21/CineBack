FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build 
WORKDIR /back-api

COPY back.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o/BACK-API/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /back-api
EXPOSE 7103

COPY --from=build /back-api/publish .

ENTRYPOINT ["dotnet", "back.dll"]