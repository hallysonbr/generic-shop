FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

COPY ["GenericShop.Services.Products.Api/GenericShop.Services.Products.Api.csproj", "GenericShop.Services.Products.Api/"]
COPY ["GenericShop.Services.Products.Application/GenericShop.Services.Products.Application.csproj", "GenericShop.Services.Products.Application/"]
COPY ["GenericShop.Services.Products.Domain/GenericShop.Services.Products.Domain.csproj", "GenericShop.Services.Products.Domain/"]
COPY ["GenericShop.Services.Products.Infra/GenericShop.Services.Products.Infra.csproj", "GenericShop.Services.Products.Infra/"]

RUN dotnet restore "GenericShop.Services.Products.Api/GenericShop.Services.Products.Api.csproj"

COPY . .

WORKDIR "/src/GenericShop.Services.Products.Api"
RUN dotnet build "GenericShop.Services.Products.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GenericShop.Services.Products.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final

WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:5002
EXPOSE 5002

ENTRYPOINT ["dotnet", "GenericShop.Services.Products.Api.dll"]