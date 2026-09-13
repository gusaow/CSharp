FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY TodoApp/TodoApp.csproj TodoApp/
RUN dotnet restore TodoApp/TodoApp.csproj

COPY . .
RUN dotnet publish TodoApp/TodoApp.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "TodoApp.dll"]
