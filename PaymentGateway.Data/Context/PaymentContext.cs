using Microsoft.EntityFrameworkCore;
using PaymentGatewayData.Models;

namespace PaymentGatewayData.Context
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options)
            : base(options)
        {
        }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}