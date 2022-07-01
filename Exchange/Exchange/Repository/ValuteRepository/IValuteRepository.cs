using Exchange.Pagination;
using exchangeRate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchange.Repository.ValuteRepository
{
    public interface IValuteRepository
    {
        Task<ICollection<Valute>> GetValute(ValuteParameters valuteParameters);
        Task<Valute> GetById(int id);
        Task<Valute> UpdateValute(int id, Valute editModel);

    }
}
