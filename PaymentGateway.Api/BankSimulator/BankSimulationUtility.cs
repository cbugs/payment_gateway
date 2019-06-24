using PaymentGateway.Api.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentGateway.Api.Models;

namespace PaymentGateway.Api.Utility
{
    public class BankSimulationUtility
    {
        public static BankObject ProcessCreditCard(CreditCard paymentObject)
        {
            var bankObject = new BankObject()
            {
                id = new Guid(),
                status = !String.IsNullOrEmpty(paymentObject.CVC)
            };
            return bankObject;
        }

        public static BankObject ProcessEWallet(EWallet paymentObject)
        {
            var bankObject = new BankObject()
            {
                id = new Guid(),
                status = !String.IsNullOrEmpty(paymentObject.Username)
            };
            return bankObject;
        }
    }
}
