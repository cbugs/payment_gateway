using Microsoft.EntityFrameworkCore;
using PaymentGateway.Data.Entity;

namespace PaymentGateway.Data.Context
{
    public class MerchantContext : DbContext
    {
        public MerchantContext(DbContextOptions<MerchantContext> options) : base(options)
        {
        }

        public DbSet<Merchant> Merchants { get; set; }
    }
}
