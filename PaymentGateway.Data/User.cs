using System.Collections.Generic;
using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public string UserEmail { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
