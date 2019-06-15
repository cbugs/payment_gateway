using System;

namespace PaymentGateway.Data.Entity
{
    public class Merchant : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
