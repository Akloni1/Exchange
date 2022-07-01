using AutoMapper;
using Exchange.Pagination;
using Exchange.Services.ValuteServices;
using exchangeRate.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exchangeRate.Controllers
{
    [Route("api")]
    [ApiController]
    public class ValuteApiController : ControllerBase
    {
        private readonly IValuteServices _valuteServices;
        public ValuteApiController(ExchangeContext context, IMapper mapper, IValuteServices valuteServices)
        {
            _valuteServices = valuteServices;
        }

        [HttpGet] // GET
        [Route("currencies")]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ICollection<ValuteViewModel>>> GetValute([FromQuery] ValuteParameters valuteParameters)
        {
            var valutes = await _valuteServices.GetValute(valuteParameters);
            if (valutes == null) return NotFound();
            return Ok(valutes);
        }

        [HttpGet] // GET
        [Route("currency/{id?}")]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var valutes = await _valuteServices.GetById(id);
            if (valutes == null) return NotFound();
            return Ok(valutes);
        }

        [HttpPut]
        [Route("currency/{id?}")]
        public async Task<IActionResult> UpdateValute(int id, EditValuteViewModel editModel)
        {
            var valutes = await _valuteServices.UpdateValute(id, editModel);
            if (valutes == null) return BadRequest();
            return Ok(valutes);
        }

    }
}
