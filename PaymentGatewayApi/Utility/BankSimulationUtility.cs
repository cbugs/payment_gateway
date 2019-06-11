using PaymentGatewayApi.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayApi.Utility
{
    public class BankSimulationUtility
    {
        public static bool ProcessCreditCard(CreditCard paymentObject)
        {
            return !String.IsNullOrEmpty(paymentObject.CVC);
        }

        public static bool ProcessEWallet(EWallet paymentObject)
        {
             return !String.IsNullOrEmpty(paymentObject.Username);
        }
    }
}
