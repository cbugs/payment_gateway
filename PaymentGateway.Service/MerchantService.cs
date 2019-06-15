using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PaymentGateway.Data.Entity;
using PaymentGateway.Data.Repository.Interface;
using PaymentGateway.Service.Interface;

namespace PaymentGateway.Service
{
    public class MerchantService : IMerchantService
    {
        private IMerchantRepository _merchantRepository;

        public MerchantService(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        private string HashPassword(string Password)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(Password));
            return string.Concat(hash.Select(b => b.ToString("X2")));
        }

        public void CreateMerchant(Merchant merchant)
        {
            merchant.Password = HashPassword(merchant.Password);
            _merchantRepository.Add(merchant);
        }

        public Merchant Login(string Username, string Password)
        {
            Merchant merchant = _merchantRepository.GetByUsernameAndPassword(Username, HashPassword(Password));
            return merchant;
        }
        public bool CheckIfUsernameExists(string Username)
        {
            Merchant merchant = _merchantRepository.GetByUsername(Username);
            return merchant != null;
        }
        public void UpdateMerchant(Merchant merchant)
        {
            merchant.Password = String.IsNullOrEmpty(merchant.Password) ? merchant.Password : HashPassword(merchant.Password);
            _merchantRepository.Update(merchant);
        }

        public List<Merchant> ListMerchants()
        {
            return _merchantRepository.GetAll().ToList();
        }

        public Merchant GetMerchant(Guid id)
        {
            return _merchantRepository.Get(id);
        }

        public void DeleteMerchant(Merchant merchant)
        {
            _merchantRepository.Delete(merchant);
        }
    }
}
