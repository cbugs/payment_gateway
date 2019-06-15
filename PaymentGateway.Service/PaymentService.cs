using System;
using System.Collections.Generic;
using PaymentGateway.Data.Entity;
using PaymentGateway.Data.Repository.Interface;
using PaymentGateway.Service.Interface;

namespace PaymentGateway.Service
{
    public class PaymentService : IPaymentService
    {
        private IUserRepository _userRepository;
        private IPaymentRepository _paymentRepository;
        private IMerchantRepository _merchantRepository;

        public PaymentService(IMerchantRepository merchantRepository, IPaymentRepository paymentRepository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _paymentRepository = paymentRepository;
            _merchantRepository = merchantRepository;
        }

        public void AddPayment(Payment payment)
        {
            var user = _userRepository.Get(payment.UserId);

            if (user == null) { throw new Exception("User Does not exist"); }

            // Initialise payments of user
            if (user.Payments == null)
            {
                user.Payments = new List<Payment>();
            }

            user.Payments.Add(payment);
            _userRepository.Update(user);
        }

        public Payment GetPayment(Guid id)
        {
            return _paymentRepository.Get(id);
        }

        public List<Payment> GetPaymentsByUser(Guid UserId, Guid MerchantId)
        {
            return _paymentRepository.GetPaymentsByUserAndMerchant(UserId, MerchantId);
        }
    }
}
