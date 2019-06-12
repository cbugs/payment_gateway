using Microsoft.EntityFrameworkCore;
using PaymentGateway.Data.Context;
using PaymentGateway.Data.Models;
using PaymentGateway.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Data.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        readonly PaymentContext _context;

        public PaymentRepository(PaymentContext context)
        {
            _context = context;
        }

        public void AddPayment(Payment entity)
        {
            var user = _context.Users.Where(u => u.UserId == entity.UserId).FirstOrDefault();

            if(user == null) { throw new Exception("User Does not exist"); }

            if(user.Payments == null)
            {
                user.Payments = new List<Payment>();
            }
            user.Payments.Add(entity);
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Add(Payment entity)
        {
            _context.Payments.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Payment entity)
        {
            _context.Payments.Remove(entity);
            _context.SaveChanges();
        }

        public Payment Get(Guid id)
        {
            return _context.Payments.Find(id);
        }

        public IEnumerable<Payment> GetAll()
        {
            return _context.Payments;
        }

        public void Update(Payment entity)
        {
            _context.Payments.Update(entity);
            _context.SaveChanges();
        }

        public List<Payment> GetPaymentsByUser(Guid userId, Guid merchantId)
        {
            return _context.Payments.Where(p => p.UserId == userId && p.MerchantId == merchantId).ToList();
        }
    }
}
