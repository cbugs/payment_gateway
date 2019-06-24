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
    public class UserRepository : IUserRepository
    {
        readonly PaymentContext _context;

        public UserRepository(PaymentContext context)
        {
            _context = context;
        }

        public async Task Add(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User entity)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByCondition(Expression<Func<User, bool>> expression)
        {
            return await _context.Users.Where(expression).AsNoTracking().ToListAsync();
        }
    }
}
