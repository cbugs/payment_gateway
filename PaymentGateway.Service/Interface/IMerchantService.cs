using PaymentGateway.Data.Entity;
using System;
using System.Collections.Generic;

namespace PaymentGateway.Service.Interface
{
    public interface IMerchantService
    {
        List<Merchant> ListMerchants();
        Merchant GetMerchant(Guid id);
        void DeleteMerchant(Merchant merchant);
        void CreateMerchant(Merchant merchant);
        Merchant Login(string username, string password);
        bool CheckIfUsernameExists(string username);
        void UpdateMerchant(Merchant merchant);
    }
}
