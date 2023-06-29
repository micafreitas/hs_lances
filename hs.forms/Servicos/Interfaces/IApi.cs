using hs.entidades;

namespace hs.forms.Servicos.Interfaces
{
    public interface IApi
    {
        Task<ChaveApp> BuscarChaveApp(string chaveApp);

        Task<ContaAcesso> BuscarContas(ChaveApp chaveApp);
    }
}
