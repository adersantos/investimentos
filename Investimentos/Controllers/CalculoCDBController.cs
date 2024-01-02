using Investimentos.Domain;
using Investimentos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Investimentos.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class CalculoCDBController : Controller
    {
        private CalculoCDBService _service;

        public CalculoCDBController(CalculoCDBService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<InvestimentoCDBDTO> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new InvestimentoCDBDTO
            {
                 CDI = 0,
                 TB = 0,
                 VF = 0,
                 VI = 0,
                 Periodo=0
            })
            .ToArray();
        }

        [HttpPost("calcular_investimento")]
        public IActionResult Post([FromBody] InvestimentoCDBDTO investimentoCDBDTO)
        {
            if (investimentoCDBDTO.Periodo == 0)
            {
                return BadRequest("Inserir o periodo");
            }
            var retornoInvestimento = _service.CalcularCDB(investimentoCDBDTO);
            
            return View(retornoInvestimento.ToString());
        }
    }
}
