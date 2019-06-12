using PaymentGateway.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Data.Repository.Interface
{
    public interface IMerchantRepository : IDataRepository<Merchant>
    {
        Merchant Login(string Username, string Password);
        bool CheckIfUsernameExists(string Username);
    }
}
