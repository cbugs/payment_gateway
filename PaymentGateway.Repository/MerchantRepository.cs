using Microsoft.EntityFrameworkCore;
using PaymentGateway.Data.Entity;
using PaymentGateway.Data.Repository.Interface;
using PaymentGateway.Repository.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace PaymentGateway.Data.Repository
{
    public class MerchantRepository : IMerchantRepository
    {
        readonly MerchantContext _context;

        public MerchantRepository(MerchantContext context)
        {
            _context = context;
        }

        public void Add(Merchant entity)
        {
            _context.Merchants.Add(entity);
            _context.SaveChanges();
        }
        public void Delete(Merchant entity)
        {
            _context.Merchants.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Merchant entity)
        {
            _context.Merchants.Update(entity);
            _context.SaveChanges();
        }

        IQueryable<Merchant> IDataRepository<Merchant>.GetAll()
        {
            return _context.Merchants.AsNoTracking();
        }

        public IQueryable<Merchant> GetByCondition(Expression<Func<Merchant, bool>> expression)
        {
            return _context.Merchants.Where(expression).AsNoTracking();
        }
    }
}
