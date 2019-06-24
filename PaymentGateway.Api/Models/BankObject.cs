using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Models
{
    public class BankObject
    {
        public Guid id { get; set; }
        public bool status { get; set; }
    }
}
