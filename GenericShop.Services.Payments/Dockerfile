FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5004

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["GenericShop.Services.Payments.Api/GenericShop.Services.Payments.Api.csproj", "GenericShop.Services.Payments.Api/"]
COPY ["GenericShop.Services.Payments.Infra/GenericShop.Services.Payments.Infra.csproj", "GenericShop.Services.Payments.Infra/"]
COPY ["GenericShop.Services.Payments.Domain/GenericShop.Services.Payments.Domain.csproj", "GenericShop.Services.Payments.Domain/"]

RUN dotnet restore "GenericShop.Services.Payments.Api/GenericShop.Services.Payments.Api.csproj"

COPY . .
WORKDIR "/src/GenericShop.Services.Payments.Api"
RUN dotnet build "GenericShop.Services.Payments.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GenericShop.Services.Payments.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:5004

ENTRYPOINT ["dotnet", "GenericShop.Services.Payments.Api.dll"]