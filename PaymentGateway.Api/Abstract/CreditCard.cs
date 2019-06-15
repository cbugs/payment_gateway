using Newtonsoft.Json;
using PaymentGateway.Api.Utility;
using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Api.Abstract
{
    public class CreditCard : AbstractPayment
    {
        [Required(ErrorMessage = "CardNumber is required")]
        [JsonProperty(Required = Required.Always)]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "FullName is required")]
        [JsonProperty(Required = Required.Always)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [JsonProperty(Required = Required.Always)]
        public string Address { get; set; }
        [Required(ErrorMessage = "ExpiryMonth is required")]
        [JsonProperty(Required = Required.Always)]
        public string ExpiryMonth { get; set; }
        [Required(ErrorMessage = "ExpiryYear is required")]
        [JsonProperty(Required = Required.Always)]
        public string ExpiryYear { get; set; }
        [Required(ErrorMessage = "CVC is required")]
        [JsonProperty(Required = Required.Always)]
        public string CVC { get; set; }

        public CreditCard(string cardNumber, string fullName, string address, string expiryMonth, string expiryYear, string cVC)
        {
            CardNumber = cardNumber;
            FullName = fullName;
            Address = address;
            ExpiryMonth = expiryMonth;
            ExpiryYear = expiryYear;
            CVC = cVC;
        }

        public override bool Process()
        {
            return BankSimulationUtility.ProcessCreditCard(this);
        }
    }
}
