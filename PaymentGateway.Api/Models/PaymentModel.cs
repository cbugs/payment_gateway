using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayApi.Models
{
    public class PaymentModel
    {
        [Required(ErrorMessage = "PaymentMethod is required")]
        public string PaymentMethod { get; set; }
        [Required(ErrorMessage = "UserId is required")]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Values is required")]
        public string Values { get; set; }
        [RegularExpression("^[^0]{1}.*$", ErrorMessage = "Amount cannot be empty")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "Details is required")]
        public string Details { get; set; }
    }
}
