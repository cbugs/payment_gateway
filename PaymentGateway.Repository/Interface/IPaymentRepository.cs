using PaymentGateway.Data.Entity;
using System;
using System.Collections.Generic;

namespace PaymentGateway.Data.Repository.Interface
{
    public interface IPaymentRepository : IDataRepository<Payment>
    {
        List<Payment> GetPaymentsByUserAndMerchant(Guid userId, Guid merchantId);
    }
}
