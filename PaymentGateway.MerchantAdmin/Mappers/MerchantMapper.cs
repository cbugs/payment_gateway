using AutoMapper;
using PaymentGateway.Domain.Entities;
using PaymentGateway.MerchantAdmin.Models;

namespace PaymentGateway.MerchantAdmin.Mappers
{
    public class MerchantMapper : Profile
    {
        public MerchantMapper()
        {
            CreateMap<Merchant, MerchantViewModel>()
                .ForMember(vm => vm.OldUsername, opts => opts.MapFrom(model => model.Username));
            CreateMap<MerchantViewModel, Merchant>();
        }
    }
}
