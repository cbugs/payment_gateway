﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Abstract.Factory
{
    public abstract class PaymentFactory
    {
        public abstract AbstractPayment CreatePaymentMethod(string values);
    }
}