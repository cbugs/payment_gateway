FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["PaymentGateway.Api/PaymentGateway.Api.csproj", "PaymentGateway.Api/"]
COPY ["Service.Interfaces/PaymentGateway.Service.Interfaces.csproj", "Service.Interfaces/"]
COPY ["PaymentGateway.Domain.Interfaces/PaymentGateway.Repository.Interfaces.csproj", "PaymentGateway.Domain.Interfaces/"]
COPY ["PaymentGateway.Data/PaymentGateway.Domain.Entities.csproj", "PaymentGateway.Data/"]
COPY ["PaymentGateway.Repository/PaymentGateway.Infrastructure.Repository.csproj", "PaymentGateway.Repository/"]
COPY ["PaymentGateway.Service/PaymentGateway.Service.csproj", "PaymentGateway.Service/"]
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