﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Merchant.Admin.Models
{
    public class MerchantViewModel
    {
        public Guid MerchantId { get; set; }
        [Required]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression(@".{8,}", ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; }
        public string OldUsername { get; set; }
    }
}
