using PaymentGatewayData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayData.Repository.Interface
{
    public interface IUserRepository: IDataRepository<User>
    {
        Guid RetrieveUser(Guid UserId, string UserEmail);
    }
}
