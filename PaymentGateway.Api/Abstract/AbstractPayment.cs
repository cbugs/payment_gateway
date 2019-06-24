using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentGateway.Api.Models;
using PaymentGateway.Api.Utility;

namespace PaymentGateway.Api.Abstract
{
    public abstract class AbstractPayment
    {
        public double Amount { get; set; }
        public string Details { get; set; }
        public bool Status { get; set; }
        public abstract BankObject Process();
    }
}
