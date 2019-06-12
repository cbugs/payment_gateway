using PaymentGateway.Data.Context;
using PaymentGateway.Data.Models;
using PaymentGateway.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Data.Repository
{
    public class MerchantRepository : IMerchantRepository
    {
        readonly MerchantContext _context;

        public string HashPassword(string Password)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(Password));
            return string.Concat(hash.Select(b => b.ToString("X2")));
        }

        public MerchantRepository(MerchantContext context)
        {
            _context = context;
        }

        public void Add(Merchant entity)
        {
            entity.Password = HashPassword(entity.Password);
            _context.Merchants.Add(entity);
            _context.SaveChanges();
        }

        public bool CheckIfUsernameExists(string Username)
        {
            return _context.Merchants.Where(m => m.Username == Username).Count() > 0;
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

        public Merchant Login(string Username, string Password)
        {
            return _context.Merchants.Where(m => m.Username == Username && m.Password == HashPassword(Password)).FirstOrDefault();
        }

        public void Update(Merchant entity)
        {
            entity.Password = String.IsNullOrEmpty(entity.Password)?entity.Password:HashPassword(entity.Password);
            _context.Merchants.Update(entity);
            _context.SaveChanges();
        }
    }
}
