using PaymentGateway.Data.Entity;
using PaymentGateway.Data.Repository.Interface;
using PaymentGateway.Service.Interface;
using System;

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
        public Guid RetrieveUser(Guid UserId, string UserEmail)
        {
            User user = _userRepository.GetUserByIdOrEmail(UserId, UserEmail);
            if (user == null)
            {
                user = new User()
                {
                    UserEmail = UserEmail,
                    Id = System.Guid.NewGuid()
                };
                _userRepository.Add(user);
            }

            //update user if email has changed and id is known
            if (UserId != null && !String.IsNullOrEmpty(UserEmail) && UserEmail != user.UserEmail)
            {
                user.UserEmail = UserEmail;
                _userRepository.Update(user);
            }

            return user.Id;
        }
    }
}
