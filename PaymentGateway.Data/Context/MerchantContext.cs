using PaymentGateway.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Data.Context
{
    public class MerchantContext:DbContext
    {
        public MerchantContext(DbContextOptions<MerchantContext> options):base(options)
        {
        }

        public DbSet<Merchant> Merchants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Merchant>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}
