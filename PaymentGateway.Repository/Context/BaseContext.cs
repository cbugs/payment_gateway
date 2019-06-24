using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Infrastructure.Repository.Context
{
    public abstract class BaseContext<TContext> : DbContext where TContext : BaseContext<TContext>
    {
        protected BaseContext(DbContextOptions<TContext> options) : base(options)
        {
        }


        public override int SaveChanges()
        {
            updateDates();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            updateDates();
            return (await base.SaveChangesAsync(true, cancellationToken));
        }


        private void updateDates()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedDate = DateTime.Now;
                }
                if (entity.State == EntityState.Modified)
                {
                    ((BaseEntity)entity.Entity).ModifiedDate = DateTime.Now;
                }
            }
        }
    }
}
