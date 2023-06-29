using hs.service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hs.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaAcessoController : Controller
    {
        private readonly IContaAcessoService _contaAcessoService;

        public ContaAcessoController(IContaAcessoService contaAcessoService)
        {
            _contaAcessoService = contaAcessoService;
        }

        [HttpGet("BuscarContasAcessos")]
        public IActionResult BuscarChaveApp([FromQuery] long chaveAppId)
        {
            var contasAcessos = _contaAcessoService.BuscarContasAcesso(chaveAppId);

            if (contasAcessos != null)
                return Ok(contasAcessos);
            else
                return NotFound();
        }
    }
}
