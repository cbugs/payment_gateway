using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Abstract.Factory
{
    public class EWalletFactory : PaymentFactory
    {
        public override AbstractPayment CreatePaymentMethod(string values)
        {
            return JsonConvert.DeserializeObject<EWallet>(values);
        }
    }
}
