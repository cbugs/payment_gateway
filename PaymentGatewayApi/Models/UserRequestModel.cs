﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayApi.Models
{
    public class UserRequestModel
    {
        public Guid UserId { get; set; }
    }
}
