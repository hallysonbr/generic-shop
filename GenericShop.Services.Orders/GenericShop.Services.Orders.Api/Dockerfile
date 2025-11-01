FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["GenericShop.Services.Orders.Api/GenericShop.Services.Orders.Api.csproj", "GenericShop.Services.Orders.Api/"]
COPY ["GenericShop.Services.Orders.Application/GenericShop.Services.Orders.Application.csproj", "GenericShop.Services.Orders.Application/"]
COPY ["GenericShop.Services.Orders.Domain/GenericShop.Services.Orders.Domain.csproj", "GenericShop.Services.Orders.Domain/"]
COPY ["GenericShop.Services.Orders.Infra/GenericShop.Services.Orders.Infra.csproj", "GenericShop.Services.Orders.Infra/"]

RUN dotnet restore "GenericShop.Services.Orders.Api/GenericShop.Services.Orders.Api.csproj"

COPY . .

WORKDIR "/src/GenericShop.Services.Orders.Api"
RUN dotnet build "GenericShop.Services.Orders.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GenericShop.Services.Orders.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app

EXPOSE 5003

COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:5003
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "GenericShop.Services.Orders.Api.dll"]