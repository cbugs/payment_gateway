using PaymentGatewayData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayData.Repository.Interface
{
    public interface IMerchantRepository : IDataRepository<Merchant>
    {
        Merchant Login(string Username, string Password);
        bool CheckIfUsernameExists(string Username);
    }
}
