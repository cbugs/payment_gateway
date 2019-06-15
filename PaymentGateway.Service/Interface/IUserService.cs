using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Service.Interface
{
    public interface IUserService
    {
        Guid RetrieveUser(Guid userId, string userEmail);
    }
}
