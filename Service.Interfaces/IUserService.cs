using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Service.Interfaces
{
    public interface IUserService
    {
        Task<Guid> RetrieveUser(Guid userId, string userEmail);
    }
}
