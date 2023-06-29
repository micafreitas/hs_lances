using hs.domain;
using hs.entidades;
using hs.service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hs.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("Merge")]
        public IActionResult MergeCliente([FromBody] CarteiraClienteDto contaCliente)
        {
            var cliente = _clienteService.Merge(contaCliente.contaAcesso, contaCliente);

            if (cliente != null)
                return Ok(cliente);
            else
                return NotFound();
        }
    }
}
