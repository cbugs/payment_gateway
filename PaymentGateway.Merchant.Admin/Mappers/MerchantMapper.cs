using AutoMapper;
using PaymentGateway.Merchant.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using PaymentGateway.Data.Models;
using System.Threading.Tasks;

namespace PaymentGateway.Merchant.Admin.Mappers
{
    public class MerchantMapper : Profile
    {
        public MerchantMapper()
        {
            CreateMap<PaymentGateway.Data.Models.Merchant, MerchantViewModel>()
                .ForMember(vm => vm.OldUsername, opts => opts.MapFrom(model => model.Username));
            CreateMap<MerchantViewModel, PaymentGateway.Data.Models.Merchant>();
        }
    }
}
