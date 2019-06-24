using PaymentGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentGateway.Service.Interfaces
{
    public interface IPaymentService
    {
        Task AddPayment(Payment payment);
        Task<IEnumerable<Payment>> GetPaymentsByMerchant(Guid merchantId);
        Task<Payment>GetPayment(Guid id);
    }
}
