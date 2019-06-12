using PaymentGateway.Data.Context;
using PaymentGateway.Data.Models;
using System;
using PaymentGateway.Data.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly PaymentContext _context;

        public UserRepository(PaymentContext context)
        {
            _context = context;
        }

        // get or generate user id based on email or user id
        public Guid RetrieveUser(Guid UserId, string UserEmail)
        {
            var user = _context.Users.Where(u => u.UserEmail == UserEmail || u.UserId == UserId).FirstOrDefault();
            if (user == null)
            {
                user = new User()
                {
                    UserEmail = UserEmail,
                    UserId = System.Guid.NewGuid()
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                return user.UserId;
            }

            //update user if necessary
            if (UserId != null && !String.IsNullOrEmpty(UserEmail) && UserEmail != user.UserEmail)
            {
                user.UserEmail = UserEmail;
                _context.Users.Update(user);
                _context.SaveChanges();
                return user.UserId;
            }
            return user.UserId;
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
