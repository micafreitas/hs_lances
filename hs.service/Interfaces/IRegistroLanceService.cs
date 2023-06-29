using hs.domain;
using hs.entidades;
using hs.entidades.Enums;

namespace hs.service.Interfaces
{
    public interface IRegistroLanceService
    {
        IList<CotaConsorcio> BuscarCotasSemLancesEfetuados(int competencia, ContaAcesso contaAcesso);

        void RegistrarLance(ChaveApp chaveApp, int competencia, CotaConsorcio cota, TipoLanceEnum tipoLance, string pageSource);

        public void RegistrarLance(ChaveApp chaveApp, int competencia, CotaConsorcio cota, TipoLanceEnum tipoLance, Exception ex, string pageSource);

        public void RegistrarLance(ChaveApp chaveApp, int competencia, CotaConsorcio cota, TipoLanceEnum tipoLance, AvisoLance aviso);
    }
}
