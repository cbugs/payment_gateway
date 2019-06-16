using System;
using PaymentGateway.Data.Repository.Interface;
using System.Linq;
using PaymentGateway.Data.Entity;
using System.Linq.Expressions;
using PaymentGateway.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace PaymentGateway.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly PaymentContext _context;

        public UserRepository(PaymentContext context)
        {
            _context = context;
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users.AsNoTracking();
        }

        public IQueryable<User> GetByCondition(Expression<Func<User, bool>> expression)
        {
            return _context.Users.Where(expression).AsNoTracking();
        }
    }
}
