using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayData.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
