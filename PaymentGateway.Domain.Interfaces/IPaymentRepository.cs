using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Repository.Interfaces
{
    public interface IPaymentRepository : IDataRepository<Payment>
    {
    }
}
