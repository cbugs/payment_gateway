using Microsoft.EntityFrameworkCore;
using PaymentGateway.Data.Entity;
using PaymentGateway.Repository.Context;

namespace PaymentGateway.Repository.Context
{
    public class PaymentContext : BaseContext<PaymentContext>
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}