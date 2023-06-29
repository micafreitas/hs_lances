using hs.domain;
using hs.entidades;

namespace hs.service.Interfaces
{
    public interface ICotaConsorcioService
    {
        CotaConsorcio Merge(ContaAcesso contaAcesso, CarteiraClienteDto carteiraCliente);
    }
}
