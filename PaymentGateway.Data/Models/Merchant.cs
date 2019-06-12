﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Data.Models
{
    public class Merchant
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MerchantId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
