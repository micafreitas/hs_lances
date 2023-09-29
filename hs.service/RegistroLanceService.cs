using hs.db.Interfaces;
using hs.entidades;
using hs.entidades.Enums;
using hs.service.Interfaces;

namespace hs.service
{
    public class RegistroLanceService : ServiceBase, IRegistroLanceService
    {
        private readonly IAvisoLanceService _avisoLanceService;

        public RegistroLanceService(IContextoDb db, IAvisoLanceService avisoLanceService) : base(db)
        {
            _avisoLanceService = avisoLanceService;
        }

        public IList<CotaConsorcio> BuscarCotasSemLancesEfetuados(int competencia, ContaAcesso contaAcesso)
        {
            var cotas = _db.CotaConsorcio
                .Where(x =>
                    x.ContaAcessoId == contaAcesso.Id &&
                    !x.RegistrosLances.Any(l => 
                        l.Competencia == competencia &&
                        (l.AvisoLance.LanceEfetuado || l.AvisoLance.RestricaoLance || l.AvisoLance.LanceEfetuadoAnteriormente)
                     )
                )
                .ToList();

            foreach (var cota in cotas)
            {
                if (cota.Cliente == null)
                    cota.Cliente = _db.Cliente.Find(cota.ClienteId);
            }

            return cotas;
        }

        public void RegistrarLance(ChaveApp chaveApp, int competencia, CotaConsorcio cota, TipoLanceEnum tipoLance, string pageSource)
        {
            var aviso = _avisoLanceService.BuscarAvisoNaPagina(pageSource);
            
            var registroLance = new RegistroLance()
            {
                ChaveAppId = chaveApp.Id,
                AvisoLanceId = aviso.Id,
                TipoLanceId = (long)tipoLance,
                Competencia = competencia,
                CotaConsorcioId = cota.Id,
                MsgAviso = aviso!.Aviso,
                MsgErro = string.Empty,
                DhLance = DateTime.Now.ToUniversalTime(),
                Sucesso = aviso == null,
                HtmlPagina = pageSource
            };

            _db.RegistroLance.Add(registroLance);
            _db.SaveChanges();
        }

        public void RegistrarLance(ChaveApp chaveApp, int competencia, CotaConsorcio cota, TipoLanceEnum tipoLance, Exception ex, string pageSource)
        {
            var aviso = _avisoLanceService.BuscarAvisoNaPagina(pageSource);
            var innerException = ex.InnerException != null ? ex.InnerException.Message : string.Empty;

            //if (aviso)
            //{

            //}

            var registroLance = new RegistroLance()
            {
                ChaveAppId = chaveApp.Id,
                AvisoLanceId = aviso.Id,
                TipoLanceId = (long)tipoLance,
                Competencia = competencia,
                CotaConsorcioId = cota.Id,
                MsgAviso = aviso!.Aviso,
                MsgErro = $"{ex.Message} - [InnerException] {innerException}",
                DhLance = DateTime.Now.ToUniversalTime(),
                Sucesso = false,
                HtmlPagina = pageSource
            };

            _db.RegistroLance.Add(registroLance);
            _db.SaveChanges();
        }

        public void RegistrarLance(ChaveApp chaveApp, int competencia, CotaConsorcio cota, TipoLanceEnum tipoLance, AvisoLance aviso)
        {
            var registroLance = new RegistroLance()
            {
                ChaveAppId = chaveApp.Id,
                AvisoLanceId = aviso.Id,
                TipoLanceId = (long)tipoLance,
                Competencia = competencia,
                CotaConsorcioId = cota.Id,
                MsgAviso = aviso!.Aviso,
                MsgErro = String.Empty,
                DhLance = DateTime.Now.ToUniversalTime(),
                Sucesso = aviso.LanceEfetuado
            };

            _db.RegistroLance.Add(registroLance);
            _db.SaveChanges();
        }
    }
}
