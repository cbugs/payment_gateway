using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Data.Context
{
    public class MerchantDBContextFactory : IDesignTimeDbContextFactory<MerchantContext>
    {
        MerchantContext IDesignTimeDbContextFactory<MerchantContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<MerchantContext>();
            var connectionString = configuration.GetConnectionString("MerchantDB");

            builder.UseSqlServer(connectionString);
            //builder.UseNpgsql(connectionString);

            return new MerchantContext(builder.Options);
        }
    }
}