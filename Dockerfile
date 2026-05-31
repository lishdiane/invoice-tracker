FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["invoice-tracker/invoice-tracker.csproj", "invoice-tracker/"]
RUN dotnet restore "invoice-tracker/invoice-tracker.csproj"
COPY . .
WORKDIR "/src/invoice-tracker"
RUN dotnet build "invoice-tracker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "invoice-tracker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "invoice-tracker.dll"]