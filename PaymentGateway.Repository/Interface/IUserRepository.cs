using PaymentGateway.Data.Entity;
using System;

namespace PaymentGateway.Data.Repository.Interface
{
    public interface IUserRepository: IDataRepository<User>
    {
        User GetUserByIdOrEmail(Guid UserId, string UserEmail);
    }
}
