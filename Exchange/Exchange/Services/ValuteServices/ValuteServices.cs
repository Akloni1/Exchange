using AutoMapper;
using Exchange.Pagination;
using Exchange.Repository.ValuteRepository;
using exchangeRate;
using exchangeRate.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchange.Services.ValuteServices
{
    public class ValuteServices : IValuteServices
    {
        private readonly IMapper _mapper;
        private readonly IValuteRepository _valuteRepository;

        public ValuteServices(IMapper mapper, IValuteRepository valuteRepository)
        {
            _mapper = mapper;
            _valuteRepository = valuteRepository;
        }

        public async Task<ICollection<ValuteViewModel>> GetValute(ValuteParameters valuteParameters)
        {
            var valutes = _mapper.Map<ICollection<Valute>, ICollection<ValuteViewModel>>(await _valuteRepository.GetValute(valuteParameters));
            return valutes;

        }


        public async Task<ValuteViewModel> GetById(int id)
        {
            var valutes = _mapper.Map<ValuteViewModel>(await _valuteRepository.GetById(id));
            return valutes;
        }



        public async Task<EditValuteViewModel> UpdateValute(int id, EditValuteViewModel editModel)
        {


            var valute = await _valuteRepository.UpdateValute(id, _mapper.Map<Valute>(editModel));
            if (valute == null)
            {
                return null;
            }
            return _mapper.Map<EditValuteViewModel>(valute);

        }

    }
}
