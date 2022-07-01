using Exchange.Pagination;
using exchangeRate;
using exchangeRate.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exchange.Repository.ValuteRepository
{
    public class ValuteRepository : IValuteRepository
    {
        private readonly ExchangeContext _context;
        public ValuteRepository(ExchangeContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Valute>> GetValute(ValuteParameters valuteParameters)
        {
            var valutes = await _context.Valutes.Skip((valuteParameters.PageNumber - 1) * valuteParameters.PageSize)
            .Take(valuteParameters.PageSize).ToListAsync();
            return valutes;
        }

        public async Task<Valute> GetById(int id)
        {
            var valutes = await _context.Valutes.FirstOrDefaultAsync(m => m.Id == id);
            return valutes;
        }

        public async Task<Valute> UpdateValute(int id, Valute editModel)
        {
            try
            {
                editModel.Id = id;
                _context.Update(editModel);
                await _context.SaveChangesAsync();
                return editModel;
            }
            catch (DbUpdateException)
            {
                if (!await ValuteExists(id))
                {
                    return null;
                }
                else
                {
                    return null;
                }
            }


        }
        private async Task<bool> ValuteExists(int id)
        {
            return await _context.Valutes.AnyAsync(e => e.Id == id);
        }
    }
}
