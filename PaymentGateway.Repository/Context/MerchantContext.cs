using Microsoft.EntityFrameworkCore;
using PaymentGateway.Data.Entity;

namespace PaymentGateway.Repository.Context
{
    public class MerchantContext : BaseContext<MerchantContext>
    {
        public MerchantContext(DbContextOptions<MerchantContext> options) : base(options)
        {
        }

        public DbSet<Merchant> Merchants { get; set; }
    }
}
