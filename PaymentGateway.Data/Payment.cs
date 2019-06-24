using System;

namespace PaymentGateway.Domain.Entities
{
    public sealed class Payment : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid MerchantId { get; set; }
        public string PaymentDetails { get; set; }
        public double PaymentAmount { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
