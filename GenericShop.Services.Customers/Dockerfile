FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["GenericShop.Services.Customers.Api/GenericShop.Services.Customers.Api.csproj", "GenericShop.Services.Customers.Api/"]
COPY ["GenericShop.Services.Customers.Application/GenericShop.Services.Customers.Application.csproj", "GenericShop.Services.Customers.Application/"]
COPY ["GenericShop.Services.Customers.Domain/GenericShop.Services.Customers.Domain.csproj", "GenericShop.Services.Customers.Domain/"]
COPY ["GenericShop.Services.Customers.Infra/GenericShop.Services.Customers.Infra.csproj", "GenericShop.Services.Customers.Infra/"]

RUN dotnet restore "GenericShop.Services.Customers.Api/GenericShop.Services.Customers.Api.csproj"
COPY . .

WORKDIR "/src/GenericShop.Services.Customers.Api"
RUN dotnet build "GenericShop.Services.Customers.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GenericShop.Services.Customers.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "GenericShop.Services.Customers.Api.dll"]