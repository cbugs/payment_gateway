using PaymentGateway.Data.Entity;
using System;
using System.Collections.Generic;

namespace PaymentGateway.Service.Interface
{
    public interface IPaymentService
    {
        void AddPayment(Payment payment);
        List<Payment> GetPaymentsByUser(Guid userId, Guid merchantId);
        Payment GetPayment(Guid id);
    }
}
