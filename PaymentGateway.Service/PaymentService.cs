using System;
using System.Collections.Generic;
using System.Linq;
using PaymentGateway.Data.Entity;
using PaymentGateway.Data.Repository.Interface;
using PaymentGateway.Service.Interface;

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

        public void AddPayment(Payment payment)
        {
            var user = _userRepository.GetByCondition(p => p.Id == payment.UserId).FirstOrDefault();

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
            return _paymentRepository.GetByCondition(p => p.Id == id).FirstOrDefault();
        }

        public List<Payment> GetPaymentsByUser(Guid userId, Guid merchantId)
        {
            return _paymentRepository.GetByCondition(p => p.UserId == userId && p.MerchantId == merchantId).ToList();
        }
    }
}
