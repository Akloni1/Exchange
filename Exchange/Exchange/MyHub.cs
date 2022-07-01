using exchangeRate;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Exchange
{
    public class MyHub : Hub
    {
      
        private decimal dolarPrice;
      
       
        public async Task Send(string message)
        {
            Thread.Sleep(1000);
            dolarPrice = await Get();
            await this.Clients.All.SendAsync("Send", $"Цена доллара = {dolarPrice} " + message);

        }

        public async Task<decimal> Get()
        {
            ExchangeContext _context = new ExchangeContext();
            var dolar = await _context.Valutes.FirstOrDefaultAsync(m => m.CharCode == "USD");
            return (decimal)dolar.Value;
        }
    }
}
