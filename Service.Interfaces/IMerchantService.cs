using PaymentGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentGateway.Service.Interfaces
{
    public interface IMerchantService
    {
        Task<IEnumerable<Merchant>> ListMerchants();
        Task<Merchant> GetMerchant(Guid id);
        Task DeleteMerchant(Merchant merchant);
        Task CreateMerchant(Merchant merchant);
        Task<Merchant> Login(string username, string password);
        Task<bool> CheckIfUsernameExists(string username);
        Task UpdateMerchant(Merchant merchant);
    }
}
