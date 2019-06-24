using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Repository.Interfaces;
using PaymentGateway.Service;
using PaymentGateway.Service.Interfaces;

namespace PaymentGateway.Service
{
    public class MerchantService : IMerchantService
    {
        private readonly IMerchantRepository _merchantRepository;

        public MerchantService(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        private string HashPassword(string password)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(password));
            return string.Concat(hash.Select(b => b.ToString("X2")));
        }

        public async Task CreateMerchant(Merchant merchant)
        {
            merchant.Password = HashPassword(merchant.Password);
            await _merchantRepository.Add(merchant);
        }

        public async Task<Merchant> Login(string username, string password)
        {
            var merchant = await _merchantRepository.GetByCondition(m => m.Username == username && m.Password == HashPassword(password));
            return merchant.FirstOrDefault();
        }

        public async Task<bool> CheckIfUsernameExists(string username)
        {
            var merchant = await _merchantRepository.GetByCondition(m => m.Username == username);
            return merchant.FirstOrDefault() != null;
        }

        public async Task UpdateMerchant(Merchant merchant)
        {
            merchant.Password = String.IsNullOrEmpty(merchant.Password) ? merchant.Password : HashPassword(merchant.Password);
            await _merchantRepository.Update(merchant);
        }

        public async Task<IEnumerable<Merchant>> ListMerchants()
        {
            return await _merchantRepository.GetAll();
        }

        public async Task<Merchant> GetMerchant(Guid Id)
        {
            var merchant = await _merchantRepository.GetByCondition(m => m.Id == Id);
            return merchant.FirstOrDefault();
        }

        public async Task DeleteMerchant(Merchant merchant)
        {
            await _merchantRepository.Delete(merchant);
        }
    }
}
