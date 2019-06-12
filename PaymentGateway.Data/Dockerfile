FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["PaymentGateway.Data./PaymentGateway.Data..csproj", "PaymentGateway.Data./"]
RUN dotnet restore "PaymentGateway.Data./PaymentGateway.Data..csproj"
COPY . .
WORKDIR "/src/PaymentGateway.Data."
RUN dotnet build "PaymentGateway.Data..csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PaymentGateway.Data..csproj" -c Release -o /app
#
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PaymentGateway.Data..dll"]

FROM build AS setup
WORKDIR "/src/PaymentGateway.Data."
RUN dotnet ef database update --context=PaymentContext
RUN dotnet ef database update --context=MerchantContext