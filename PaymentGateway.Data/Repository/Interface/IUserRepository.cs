using PaymentGateway.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Data.Repository.Interface
{
    public interface IUserRepository: IDataRepository<User>
    {
        Guid RetrieveUser(Guid UserId, string UserEmail);
    }
}
