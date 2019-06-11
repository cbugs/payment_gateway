FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["PaymentGatewayData/PaymentGatewayData.csproj", "PaymentGatewayData/"]
RUN dotnet restore "PaymentGatewayData/PaymentGatewayData.csproj"
COPY . .
WORKDIR "/src/PaymentGatewayData"
RUN dotnet build "PaymentGatewayData.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PaymentGatewayData.csproj" -c Release -o /app
#
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PaymentGatewayData.dll"]

FROM build AS setup
WORKDIR "/src/PaymentGatewayData"
RUN dotnet ef database update --context=PaymentContext
RUN dotnet ef database update --context=MerchantContext