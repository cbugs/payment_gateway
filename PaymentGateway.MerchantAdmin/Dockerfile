FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["PaymentGateway.MerchantAdmin/PaymentGateway.MerchantAdmin.csproj", "PaymentGateway.MerchantAdmin/"]
COPY ["PaymentGateway.Service/PaymentGateway.Service.csproj", "PaymentGateway.Service/"]
COPY ["PaymentGateway.Repository/PaymentGateway.Repository.csproj", "PaymentGateway.Repository/"]
COPY ["PaymentGateway.Data/PaymentGateway.Data.csproj", "PaymentGateway.Data/"]
RUN dotnet restore "PaymentGateway.MerchantAdmin/PaymentGateway.MerchantAdmin.csproj"
COPY . .
WORKDIR "/src/PaymentGateway.MerchantAdmin"
RUN dotnet build "PaymentGateway.MerchantAdmin.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PaymentGateway.MerchantAdmin.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PaymentGateway.MerchantAdmin.dll"]