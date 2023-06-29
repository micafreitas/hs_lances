using hs.entidades;
using hs.service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hs.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChaveAcessoController : Controller
    {
        private readonly IChaveAppService _chaveAppService;

        public ChaveAcessoController(IChaveAppService chaveAppService)
        {
            _chaveAppService = chaveAppService;
        }

        [HttpGet("BuscarChaveApp")]
        public IActionResult BuscarChaveApp([FromQuery]Guid chaveApp)
        {
            var chave = _chaveAppService.BuscarChaveApp(chaveApp.ToString());

            if (chave != null)
                return Ok(chave);
            else
                return NotFound();
        }
    }
}
