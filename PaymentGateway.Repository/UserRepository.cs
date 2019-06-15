using PaymentGateway.Data.Context;
using System;
using PaymentGateway.Data.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using PaymentGateway.Data.Entity;

namespace PaymentGateway.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly PaymentContext _context;

        public UserRepository(PaymentContext context)
        {
            _context = context;
        }

        public User GetUserByIdOrEmail(Guid UserId, string UserEmail)
        {
            return _context.Users.Where(u => u.UserEmail == UserEmail || u.Id == UserId).FirstOrDefault();
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

        public User Get(Guid id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}
