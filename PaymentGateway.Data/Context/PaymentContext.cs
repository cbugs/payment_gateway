using Microsoft.EntityFrameworkCore;
using PaymentGateway.Data.Models;

namespace PaymentGateway.Data.Context
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