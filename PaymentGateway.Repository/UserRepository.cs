using System;
using PaymentGateway.Data.Repository.Interface;
using System.Linq;
using PaymentGateway.Data.Entity;
using System.Linq.Expressions;
using PaymentGateway.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PaymentGateway.Data.Repository
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
