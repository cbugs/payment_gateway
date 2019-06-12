using PaymentGateway.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Data.Repository.Interface
{
    public interface IPaymentRepository : IDataRepository<Payment>
    {
        void AddPayment(Payment entity);
        List<Payment> GetPaymentsByUser(Guid userId, Guid merchantId);
    }
}
