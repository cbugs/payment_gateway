using Microsoft.EntityFrameworkCore;
using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Infrastructure.Repository.Context
{
    public class MerchantContext : BaseContext<MerchantContext>
    {
        public MerchantContext(DbContextOptions<MerchantContext> options) : base(options)
        {
        }

        public DbSet<Merchant> Merchants { get; set; }
    }
}
