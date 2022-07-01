using AutoMapper;
using exchangeRate;
using exchangeRate.ViewModels;

namespace Exchange.ViewModels.AutoMapperProfiles
{
    public class ValuteProfile : Profile
    {
        public ValuteProfile()
        {
            CreateMap<Valute, EditValuteViewModel>().ReverseMap();
            CreateMap<Valute, ValuteViewModel>();
        }
    }
}
