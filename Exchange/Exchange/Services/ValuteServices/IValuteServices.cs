using Exchange.Pagination;
using exchangeRate.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchange.Services.ValuteServices
{
    public interface IValuteServices
    {
        Task<ICollection<ValuteViewModel>> GetValute(ValuteParameters valuteParameters);
        Task<ValuteViewModel> GetById(int id);
        Task<EditValuteViewModel> UpdateValute(int id, EditValuteViewModel editModel);
    }
}
