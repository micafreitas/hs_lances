using hs.domain;
using hs.entidades;
using hs.entidades.Enums;
using OpenQA.Selenium;

namespace hs.service.Interfaces
{
    public interface IPortalHsService
    {
        IWebDriver driver { get; set; }

        void NavegarPaginaLogin();

        void Logar(ContaAcesso contaAcesso);

        void AbrirRelatorioCotas();

        IList<CarteiraClienteDto> ExtrairDadosRelatorios();

        AvisoLance EfetuarLance(CotaConsorcio cotaConsorcio, TipoLanceEnum tipoLance);

        string PageSource();

        List<string> PageSourceToList();
    }
}
