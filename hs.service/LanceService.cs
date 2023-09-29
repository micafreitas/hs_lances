using hs.domain;
using hs.entidades;
using hs.entidades.Enums;
using hs.service.Interfaces;
using hs.util;

namespace hs.service
{
    public class LanceService : ILanceService
    {
        private readonly IContaAcessoService _contaAcessoService;
        private readonly IParametroService _parametroService;
        private readonly IPortalHsService _portalHsService;
        private readonly IRegistroLanceService _registroLanceService;
        private readonly IClienteService _clienteService;
        private readonly ICotaConsorcioService _cotaConsorcioService;

        private INotificacaoForm _notificacao;
        private INotificacaoAndamento _notificacaoAndamento;

        public LanceService(
            IContaAcessoService contaAcessoService, 
            IParametroService parametroService, 
            IRegistroLanceService registroLanceService,
            IClienteService clienteService,
            ICotaConsorcioService cotaConsorcioService,
            IPortalHsService portalHsService
        )
        {
            _contaAcessoService = contaAcessoService;
            _parametroService = parametroService;
            _portalHsService = portalHsService;
            _registroLanceService = registroLanceService;
            _clienteService = clienteService;
            _cotaConsorcioService = cotaConsorcioService;
        }

        public void EfetuarLances(ChaveApp chaveApp, ContaAcesso contaAcesso, INotificacaoForm notificacao, INotificacaoAndamento notificacaoAndamento)
        {
            _notificacao = notificacao;
            _notificacaoAndamento = notificacaoAndamento;

            var competencia = _parametroService.BuscarCompetenciaAtual();

            notificacao.OnMensagem("Buscando cotas sem lances para a competência atual");
            var cotasSemLance = _registroLanceService.BuscarCotasSemLancesEfetuados(competencia, contaAcesso);
            if (!cotasSemLance.Any())
            {
                notificacao.OnMensagem("Sem cotas para efetuar lances");
                return;
            }

            for (int i = 0; i < cotasSemLance.Count; i++)
            {
                var cota = cotasSemLance[i];
                if (cota.Cliente == null)
                    continue;

                notificacao.OnMensagem($"Lance {i + 1} de {cotasSemLance.Count} - Cliente: {cota.Cliente.Nome}");

                foreach (TipoLanceEnum tipoLance in Enum.GetValues(typeof(TipoLanceEnum)))
                {
                    try
                    {
                        var a = "";
                        if (cota.Cota == "0977")
                            a = "a";

                        var aviso = _portalHsService.EfetuarLance(cota, tipoLance);
                        _registroLanceService.RegistrarLance(chaveApp, competencia, cota, tipoLance, aviso);
                    }
                    catch (Exception ex)
                    {
                        _registroLanceService.RegistrarLance(chaveApp, competencia, cota, tipoLance, ex, _portalHsService.PageSource());
                    }
                }

                _notificacaoAndamento.OnAndamento(i + 1, cotasSemLance.Count);
            }

            notificacao.OnMensagem(string.Empty);
        }

        public void EfetuarLances(ChaveApp chaveApp, INotificacaoForm notificacao, INotificacaoAndamento notificacaoAndamento)
        {
            _notificacao = notificacao;
            _notificacaoAndamento = notificacaoAndamento;

            var contasAcesso = _contaAcessoService.BuscarContasAcesso(chaveApp.Id);
            var competencia = _parametroService.BuscarCompetenciaAtual();

            foreach (var contaAcesso in contasAcesso)
            {
                EfetuarLances(chaveApp, notificacao, notificacaoAndamento);
                //_portalHsService.Logar(contaAcesso);
                //_portalHsService.AbrirRelatorioCotas();

                //var carteiraClientes = _portalHsService.ExtrairDadosRelatorios();

                //foreach (var cotaCliente in carteiraClientes)
                //{
                //    // TODO fazer merges em lote
                //    var cliente = MergeCliente(contaAcesso, cotaCliente);
                //    var cotaConsorsio = MergeCota(contaAcesso, cotaCliente, cliente);

                //    _db.SaveChanges();
                //}

                //var cotasSemLance = _registroLanceService.BuscarCotasSemLancesEfetuados(competencia, contaAcesso);
                //if (!cotasSemLance.Any())
                //{
                //    // TODO Mensagem sem cotas para dar lances
                //    return;
                //}

                //foreach (var cota in cotasSemLance)
                //{
                //    foreach (TipoLanceEnum tipoLance in Enum.GetValues(typeof(TipoLanceEnum)))
                //    {
                //        try
                //        {
                //            var aviso = _portalHsService.EfetuarLance(cota, tipoLance);
                //            _registroLanceService.RegistrarLance(chaveApp, competencia, cota, tipoLance, aviso);
                //        }
                //        catch (Exception ex)
                //        {
                //            _registroLanceService.RegistrarLance(chaveApp, competencia, cota, tipoLance, ex, _portalHsService.PageSource());
                //        }
                //    }
                //}
            }
        }

        public Cliente MergeCliente(ContaAcesso contaAcesso, CarteiraClienteDto carteiraCliente)
        {
            return _clienteService.Merge(contaAcesso, carteiraCliente);
        }

        public CotaConsorcio MergeCota(ContaAcesso contaAcesso, CarteiraClienteDto carteiraCliente, Cliente cliente)
        {
            return _cotaConsorcioService.Merge(contaAcesso, carteiraCliente);
        }

        public bool ExisteLanceCompetenciaAtual(CotaConsorcio cotaConsorsio)
        {
            throw new NotImplementedException();
        }

        public void ExtrairClientesCotas(ChaveApp chaveApp, ContaAcesso contaAcesso, INotificacaoForm notificacao)
        {
            _notificacao = notificacao;

            _portalHsService.NavegarPaginaLogin();
            _portalHsService.Logar(contaAcesso);
            _portalHsService.AbrirRelatorioCotas();

            notificacao.OnMensagem("Extraindo dados do relatório de cliente");
            var carteiraClientes = _portalHsService.ExtrairDadosRelatorios();


            notificacao.OnMensagem("Atualizando clientes e cotas de clientes");
            foreach (var cotaCliente in carteiraClientes)
            {
                var cliente = MergeCliente(contaAcesso, cotaCliente);
                MergeCota(contaAcesso, cotaCliente, cliente);
            }
        }

        public void BuscarIndicadoresAtualizados(ChaveApp chaveApp, ContaAcesso contaAcesso, INotificacaoForm notificacao)
        {
            throw new NotImplementedException();
        }
    }
}
