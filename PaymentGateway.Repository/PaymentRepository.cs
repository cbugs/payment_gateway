﻿using System;
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
    public class PaymentRepository : IPaymentRepository
    {
        readonly PaymentContext _context;

        public PaymentRepository(PaymentContext context)
        {
            _context = context;
        }

        public async Task Add(Payment entity)
        {
            _context.Payments.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Payment entity)
        {
            _context.Payments.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Payment entity)
        {
            _context.Payments.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Payment>> GetByCondition(Expression<Func<Payment, bool>> expression)
        {
            return await _context.Payments.Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetAll()
        {
            return await _context.Payments.AsNoTracking().ToListAsync();
        }
    }
}
