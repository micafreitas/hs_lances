using hs.domain;
using hs.service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hs.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CotaConsorcioController : Controller
    {
        private readonly ICotaConsorcioService _cotaConsorcioService;

        public CotaConsorcioController(ICotaConsorcioService cotaConsorcioService)
        {
            _cotaConsorcioService = cotaConsorcioService;
        }

        [HttpPost("Merge")]
        public IActionResult MergeCotaConsorcio([FromBody]CarteiraClienteDto contaCliente)
        {
            var cotaConsorcio = _cotaConsorcioService.Merge(contaCliente.contaAcesso, contaCliente);

            if (cotaConsorcio != null)
                return Ok(cotaConsorcio);
            else
                return NotFound();
        }
    }
}
