FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["MerchantAdmin/MerchantAdmin.csproj", "MerchantAdmin/"]
COPY ["PaymentGatewayData/PaymentGatewayData.csproj", "PaymentGatewayData/"]
RUN dotnet restore "MerchantAdmin/MerchantAdmin.csproj"
COPY . .
WORKDIR "/src/MerchantAdmin"
RUN dotnet build "MerchantAdmin.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MerchantAdmin.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MerchantAdmin.dll"]