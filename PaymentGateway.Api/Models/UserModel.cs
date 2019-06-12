using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayApi.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
    }
}
