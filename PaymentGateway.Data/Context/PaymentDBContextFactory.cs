using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PaymentGateway.Data.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Data.Context
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

            builder.UseSqlServer(connectionString);
            //builder.UseNpgsql(connectionString);

            return new PaymentContext(builder.Options);
        }
    }
}