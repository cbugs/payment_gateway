FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["PaymentGateway.Api/PaymentGateway.Api.csproj", "PaymentGateway.Api/"]
COPY ["PaymentGateway.Service/PaymentGateway.Service.csproj", "PaymentGateway.Service/"]
COPY ["PaymentGateway.Repository/PaymentGateway.Repository.csproj", "PaymentGateway.Repository/"]
COPY ["PaymentGateway.Data/PaymentGateway.Data.csproj", "PaymentGateway.Data/"]
RUN dotnet restore "PaymentGateway.Api/PaymentGateway.Api.csproj"
COPY . .
WORKDIR "/src/PaymentGateway.Api"
RUN dotnet build "PaymentGateway.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PaymentGateway.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PaymentGateway.Api.dll"]