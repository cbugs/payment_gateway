using Newtonsoft.Json;
using PaymentGateway.Api.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Abstract
{
    public class EWallet : AbstractPayment
    {
        [Required(ErrorMessage = "Username is required")]
        [JsonProperty(Required = Required.Always)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [JsonProperty(Required = Required.Always)]
        public string Password { get; set; }

        public EWallet(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public override bool Process()
        {
            return BankSimulationUtility.ProcessEWallet(this);
        }
    }
}
