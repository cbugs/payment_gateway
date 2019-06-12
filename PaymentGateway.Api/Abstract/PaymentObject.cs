using PaymentGateway.Api.Abstract.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Abstract
{
    public class PaymentObject
    {
        private readonly Dictionary<PaymentMethods, PaymentFactory> _factories;

        public PaymentObject()
        {
            _factories = new Dictionary<PaymentMethods, PaymentFactory>
            {
                { PaymentMethods.CreditCard, new CreditCardFactory() },
                { PaymentMethods.EWallet, new EWalletFactory() }
            };
        }

        public AbstractPayment Create(PaymentMethods paymentMethods, string values)
        {
            return _factories[paymentMethods].CreatePaymentMethod(values);
        }

    }
}
