using PaymentGateway.Data.Entity;

namespace PaymentGateway.Data.Repository.Interface
{
    public interface IMerchantRepository : IDataRepository<Merchant>
    {
        Merchant GetByUsernameAndPassword(string Username, string Password);
        Merchant GetByUsername(string Username);
    }
}
