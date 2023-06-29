using hs.db.Interfaces;
using hs.domain;
using hs.entidades;
using hs.service.Interfaces;

namespace hs.service
{
    public class CotaConsorcioService : ServiceBase, ICotaConsorcioService
    {
        private readonly IClienteService _clienteService;

        public CotaConsorcioService(IContextoDb db, IClienteService clienteService) : base(db)
        {
            _clienteService = clienteService;
        }

        public CotaConsorcio Merge(ContaAcesso contaAcesso, CarteiraClienteDto carteiraCliente)
        {
            var cliente = _clienteService.Merge(contaAcesso, carteiraCliente);

            var cotaConsorsio = _db.CotaConsorcio
                .Where(x =>
                        x.Cota == carteiraCliente.Cota &&
                        x.Grupo == carteiraCliente.Grupo
                )
                .FirstOrDefault();

            if (cotaConsorsio == null)
            {
                cotaConsorsio = new CotaConsorcio()
                {
                    Cota = carteiraCliente.Cota,
                    Grupo = carteiraCliente.Grupo,
                    ContaAcesso = contaAcesso,
                    Cliente = cliente
                };
            }

            cotaConsorsio.PercentualPagar = carteiraCliente.PercentualAPagar;
            cotaConsorsio.DhAtualizacaoPercentualPagar = DateTime.Now.ToUniversalTime();
            cotaConsorsio.DtContemplacao = carteiraCliente.DataContemplacao;

            _db.CotaConsorcio.Update(cotaConsorsio);
            _db.SaveChanges();

            return cotaConsorsio;
        }
    }
}
