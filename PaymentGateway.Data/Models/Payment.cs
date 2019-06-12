using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Data.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PaymentId { get; set; }
        public Guid UserId { get; set; }
        public Guid MerchantId { get; set; }
        public string PaymentDetails { get; set; }
        public double PaymentAmount { get; set; }
    }
}
