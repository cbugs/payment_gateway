using PaymentGateway.Data.Entity;
using PaymentGateway.Data.Repository.Interface;
using PaymentGateway.Service.Interface;
using System;
using System.Linq;

namespace PaymentGateway.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        //private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // get or generate user id based on email or user id
        public Guid RetrieveUser(Guid userId, string userEmail)
        {
            User user = _userRepository.GetByCondition(u => u.Id == userId || u.UserEmail == userEmail).FirstOrDefault();
            if (user == null)
            {
                user = new User()
                {
                    UserEmail = userEmail,
                    Id = System.Guid.NewGuid()
                };
                _userRepository.Add(user);
            }

            //update user if email has changed and id is known
            if (userId != null && !String.IsNullOrEmpty(userEmail) && userEmail != user.UserEmail)
            {
                user.UserEmail = userEmail;
                _userRepository.Update(user);
            }

            return user.Id;
        }
    }
}
