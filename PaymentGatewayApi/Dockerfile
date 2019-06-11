FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["PaymentGatewayApi/PaymentGatewayApi.csproj", "PaymentGatewayApi/"]
COPY ["PaymentGatewayData/PaymentGatewayData.csproj", "PaymentGatewayData/"]
RUN dotnet restore "PaymentGatewayApi/PaymentGatewayApi.csproj"
COPY . .
WORKDIR "/src/PaymentGatewayApi"
RUN dotnet build "PaymentGatewayApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PaymentGatewayApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PaymentGatewayApi.dll"]