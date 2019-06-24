using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Repository.Interfaces;
using PaymentGateway.Service.Interfaces;

namespace PaymentGateway.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task AddPayment(Payment payment)
        {
            var users = await _userRepository.GetByCondition(p => p.Id == payment.UserId);
            User user = users.FirstOrDefault();

            if (user == null) { throw new Exception("User Does not exist"); }

            // Initialise payments of user
            if (user.Payments == null)
            {
                user.Payments = new List<Payment>();
            }

            user.Payments.Add(payment);
            await _userRepository.Update(user);
        }

        public async Task<Payment> GetPayment(Guid id)
        {
            var payment = await _paymentRepository.GetByCondition(p => p.Id == id);
            return payment.FirstOrDefault();
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByMerchant(Guid merchantId)
        {
            return await _paymentRepository.GetByCondition(p => p.MerchantId == merchantId);
        }
    }
}
