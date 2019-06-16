using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PaymentGateway.Repository.Context
{
    public class PaymentDBContextFactory : IDesignTimeDbContextFactory<PaymentContext>
    {
        PaymentContext IDesignTimeDbContextFactory<PaymentContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PaymentContext>();
            var connectionString = configuration.GetConnectionString("PaymentGatewayDB");

            builder.UseSqlServer("server=localhost,1434;database=PaymentGatewayDB;User=sa;Password=Ax+themA;");

            return new PaymentContext(builder.Options);
        }
    }
}