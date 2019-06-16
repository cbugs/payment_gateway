using PaymentGateway.Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentGateway.Service.Interface
{
    public interface IPaymentService
    {
        Task AddPayment(Payment payment);
        Task<IEnumerable<Payment>> GetPaymentsByUser(Guid userId, Guid merchantId);
        Task<Payment>GetPayment(Guid id);
    }
}
