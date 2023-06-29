using hs.entidades;
using hs.entidades.Views;

namespace hs.service.Interfaces
{
    public interface IContaAcessoService
    {
        IList<ContaAcesso> BuscarContasAcesso(long chaveAppId);
    }
}
