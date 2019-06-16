using System.Collections.Generic;

namespace PaymentGateway.Data.Entity
{
    public sealed class User : BaseEntity
    {
        public string UserEmail { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
