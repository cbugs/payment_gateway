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

        public Merchant Login(string username, string password)
        {
            Merchant merchant = _merchantRepository.GetByCondition(m => m.Username == username && m.Password == HashPassword(password)).FirstOrDefault();
            return merchant;
        }
        public bool CheckIfUsernameExists(string username)
        {
            Merchant merchant = _merchantRepository.GetByCondition(m => m.Username == username).FirstOrDefault();
            return merchant != null;
        }
        public void UpdateMerchant(Merchant merchant)
        {
            merchant.Password = String.IsNullOrEmpty(merchant.Password) ? merchant.Password : HashPassword(merchant.Password);
            _merchantRepository.Update(merchant);
        }

        public List<Merchant> ListMerchants()
        {
            return _merchantRepository.GetAllAsync().ToList();
        }

        public Merchant GetMerchant(Guid Id)
        {
            return _merchantRepository.GetByCondition(m => m.Id == Id).FirstOrDefault();
        }

        public void DeleteMerchant(Merchant merchant)
        {
            _merchantRepository.Delete(merchant);
        }
    }
}
