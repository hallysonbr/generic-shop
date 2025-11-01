FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

COPY ["GenericShop.Services.Notifications.Api/GenericShop.Services.Notifications.Api.csproj", "GenericShop.Services.Notifications.Api/"]
COPY ["GenericShop.Services.Notifications.Application/GenericShop.Services.Notifications.Application.csproj", "GenericShop.Services.Notifications.Application/"]
COPY ["GenericShop.Services.Notifications.Domain/GenericShop.Services.Notifications.Domain.csproj", "GenericShop.Services.Notifications.Domain/"]
COPY ["GenericShop.Services.Notifications.Infra/GenericShop.Services.Notifications.Infra.csproj", "GenericShop.Services.Notifications.Infra/"]

RUN dotnet restore "GenericShop.Services.Notifications.Api/GenericShop.Services.Notifications.Api.csproj"

COPY . .

WORKDIR "/src/GenericShop.Services.Notifications.Api"
RUN dotnet build "GenericShop.Services.Notifications.Api.csproj" -c Release -o /app/build

RUN dotnet publish "GenericShop.Services.Notifications.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 5005

ENV ASPNETCORE_URLS=http://+:5005
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "GenericShop.Services.Notifications.Api.dll"]