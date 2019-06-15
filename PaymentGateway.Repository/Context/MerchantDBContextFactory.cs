using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

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

            builder.UseSqlServer("server=localhost,1434;database=MerchantDB;User=sa;Password=Ax+themA;");

            return new MerchantContext(builder.Options);
        }
    }
}