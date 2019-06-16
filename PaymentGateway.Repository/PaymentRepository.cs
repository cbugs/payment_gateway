using Microsoft.EntityFrameworkCore;
using PaymentGateway.Data.Entity;
using PaymentGateway.Data.Repository.Interface;
using PaymentGateway.Repository.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

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

        public void Update(Payment entity)
        {
            _context.Payments.Update(entity);
            _context.SaveChanges();
        }

        public IQueryable<Payment> GetByCondition(Expression<Func<Payment, bool>> expression)
        {
            return _context.Payments.Where(expression).AsNoTracking();
        }

        public IQueryable<Payment> GetAll()
        {
            return _context.Payments.AsNoTracking();
        }
    }
}
