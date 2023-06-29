using hs.domain;
using hs.entidades;
using hs.util;

namespace hs.service.Interfaces
{
    public interface ILanceService
    {
        void ExtrairClientesCotas(ChaveApp chaveApp, ContaAcesso contaAcesso, INotificacaoForm notificacao);

        void BuscarIndicadoresAtualizados(ChaveApp chaveApp, ContaAcesso contaAcesso, INotificacaoForm notificacao);

        void EfetuarLances(ChaveApp chaveApp, ContaAcesso contaAcesso, INotificacaoForm notificacao, INotificacaoAndamento notificacaoAndamento);

        void EfetuarLances(ChaveApp chaveApp, INotificacaoForm notificacao, INotificacaoAndamento notificacaoAndamento);

        Cliente MergeCliente(ContaAcesso contaAcesso, CarteiraClienteDto contaCliente);

        CotaConsorcio MergeCota(ContaAcesso contaAcesso, CarteiraClienteDto cota, Cliente cliente);

        bool ExisteLanceCompetenciaAtual(CotaConsorcio cotaConsorsio);
    }
}
