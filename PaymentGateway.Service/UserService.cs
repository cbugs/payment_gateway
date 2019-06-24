using System;
using System.Linq;
using System.Threading.Tasks;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Repository.Interfaces;
using PaymentGateway.Service.Interfaces;

namespace PaymentGateway.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        //private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // get or generate user id based on email or user id
        public async Task<Guid> RetrieveUser(Guid userId, string userEmail)
        {
            var users = await _userRepository.GetByCondition(u => u.Id == userId || u.UserEmail == userEmail);
            User user = users.FirstOrDefault();
            if (user == null)
            {
                user = new User()
                {
                    UserEmail = userEmail,
                    Id = System.Guid.NewGuid()
                };
                await _userRepository.Add(user);
            }

            //update user if email has changed and id is known
            if (userId != null && !String.IsNullOrEmpty(userEmail) && userEmail != user.UserEmail)
            {
                user.UserEmail = userEmail;
                await _userRepository.Update(user);
            }

            return user.Id;
        }
    }
}
