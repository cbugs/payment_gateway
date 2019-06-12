FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["PaymentGateway.Merchant.Admin/PaymentGateway.Merchant.Admin.csproj", "PaymentGateway.Merchant.Admin/"]
COPY ["PaymentGateway.Data/PaymentGateway.Data.csproj", "PaymentGateway.Data/"]
RUN dotnet restore "PaymentGateway.Merchant.Admin/PaymentGateway.Merchant.Admin.csproj"
COPY . .
WORKDIR "/src/PaymentGateway.Merchant.Admin"
RUN dotnet build "PaymentGateway.Merchant.Admin.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PaymentGateway.Merchant.Admin.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PaymentGateway.Merchant.Admin.dll"]