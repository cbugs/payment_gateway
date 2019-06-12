using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayApi.Abstract
{
    public abstract class AbstractPayment
    {
        public double Amount { get; set; }
        public string Details { get; set; }
        public abstract bool Process();
    }
}
