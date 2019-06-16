using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Service.Interface
{
    public interface IUserService
    {
        Task<Guid> RetrieveUser(Guid userId, string userEmail);
    }
}
