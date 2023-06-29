using hs.db.Interfaces;
using hs.entidades;
using hs.service.Interfaces;
using OpenQA.Selenium;
using System.Linq;

namespace hs.service
{
    // Classe deve ser singlenton no FORM
    public class AvisoLanceService : ServiceBase, IAvisoLanceService
    {
        private IList<AvisoLance> avisos;
        private AvisoLance avisoSucesso;
        private AvisoLance avisoErro;
        private AvisoLance avisoFalhaNaoMapeada;

        public AvisoLanceService(IContextoDb db) : base(db)
        {
            CarregarAvisos();
        }

        public void CarregarAvisos()
        {
            avisos = _db.AvisoLance.ToList();

            avisoSucesso = avisos.Where(x => x.LanceEfetuado).FirstOrDefault();
            avisoErro = avisos.Where(x => x.Erro).FirstOrDefault();
            avisoFalhaNaoMapeada = avisos.Where(x => x.RestricaoLance).FirstOrDefault();
        }

        public AvisoLance BuscarAvisoSucesso() => avisoSucesso;
        public AvisoLance BuscarAvisoErro() => avisoErro;
        public AvisoLance BuscarAvisoFalhaNaoMapeada() => avisoFalhaNaoMapeada;

        public AvisoLance BuscarAvisoNaPagina(string pageSource)
        {
            if (pageSource.Contains(BuscarAvisoSucesso().Aviso))
                return BuscarAvisoSucesso();

            foreach (var aviso in avisos.OrderByDescending(o => o.LanceEfetuado).ThenByDescending(o => o.LanceEfetuadoAnteriormente))
            {
                // IWebElement tdElement = driver.FindElement(By.XPath("//td[contains(text(), 'your_text_here')]"));

                if (string.IsNullOrEmpty(aviso.Mensagem))
                {
                    if (pageSource.Contains(aviso.Aviso))
                        return aviso;
                }
                else
                {
                    if (pageSource.Contains(aviso.Aviso) || pageSource.Contains(aviso.Mensagem))
                        return aviso;
                }
            }

            return avisoFalhaNaoMapeada;
        }
    }
}
