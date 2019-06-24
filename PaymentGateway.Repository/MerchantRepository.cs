using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Infrastructure.Repository.Context;
using PaymentGateway.Repository.Context;
using PaymentGateway.Repository.Interfaces;

namespace PaymentGateway.Infrastructure.Repository
{
    public class MerchantRepository : IMerchantRepository
    {
        readonly MerchantContext _context;

        public MerchantRepository(MerchantContext context)
        {
            _context = context;
        }

        public async Task Add(Merchant entity)
        {
            _context.Merchants.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Merchant entity)
        {
            _context.Merchants.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Merchant entity)
        {
            _context.Merchants.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Merchant>> GetAll()
        {
            return await _context.Merchants.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Merchant>> GetByCondition(Expression<Func<Merchant, bool>> expression)
        {
            return await _context.Merchants.Where(expression).AsNoTracking().ToListAsync();
        }
    }
}
