using PaymentGateway.Data.Context;
using PaymentGateway.Data.Entity;
using PaymentGateway.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentGateway.Data.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        readonly PaymentContext _context;

        public PaymentRepository(PaymentContext context)
        {
            _context = context;
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

        public List<Payment> GetPaymentsByUserAndMerchant(Guid userId, Guid merchantId)
        {
            return _context.Payments.Where(p => p.UserId == userId && p.MerchantId == merchantId).ToList();
        }
    }
}
