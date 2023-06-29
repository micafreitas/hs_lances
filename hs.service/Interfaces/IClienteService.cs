using hs.domain;
using hs.entidades;

namespace hs.service.Interfaces
{
    public interface IClienteService
    {
        Cliente Merge(ContaAcesso contaAcesso, CarteiraClienteDto contaCliente);
    }
}
