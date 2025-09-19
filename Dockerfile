# 1?? Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY src/Api/Api.csproj Api/
COPY src/Application/Application.csproj Application/
RUN dotnet restore Api/Api.csproj

COPY src/ ./
RUN dotnet publish Api/Api.csproj -c Release -o /app/out

# 2?? Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "Api.dll"]
