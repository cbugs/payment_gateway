using Microsoft.EntityFrameworkCore;
using PaymentGateway.Data.Context;
using PaymentGateway.Data.Entity;
using PaymentGateway.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Merchant GetByUsername(string Username)
        {
            return _context.Merchants.AsNoTracking().Where(m => m.Username == Username).FirstOrDefault();
        }

        public void Delete(Merchant entity)
        {
            _context.Merchants.Remove(entity);
            _context.SaveChanges();
        }

        public Merchant Get(Guid id)
        {
            return _context.Merchants.Find(id);
        }

        public IEnumerable<Merchant> GetAll()
        {
            return _context.Merchants;
        }

        public Merchant GetByUsernameAndPassword(string Username, string Password)
        {
            return _context.Merchants.Where(m => m.Username == Username && m.Password == Password).FirstOrDefault();
        }

        public void Update(Merchant entity)
        {          
            _context.Merchants.Update(entity);
            _context.SaveChanges();
        }
    }
}
