using System;

namespace PaymentGateway.Domain.Entities
{
    public sealed class Merchant : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
