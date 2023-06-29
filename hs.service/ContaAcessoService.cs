using hs.db.Interfaces;
using hs.entidades;
using hs.entidades.Views;
using hs.service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace hs.service
{
    public class ContaAcessoService : ServiceBase, IContaAcessoService
    {
        public ContaAcessoService(IContextoDb db) : base(db)
        { }

        public IList<ContaAcesso> BuscarContasAcesso(long chaveAppId)
        {
            var contas = _db.ContaAcesso
                .Where(x =>
                    x.Empresa.ChaveAppId == chaveAppId &&
                    x.Ativo
            )
            .ToList();

            var contasView = _db.ContaAcessoView
                .Where(x =>
                    x.ChaveAppId == chaveAppId &&
                    x.Ativo
                )
                .ToList();

            if (contasView.Any())
                foreach (var conta in contas)
                    conta.ContaAcessoView = contasView.FirstOrDefault(x => x.Id == conta.Id);

            return contas;
        }
    }
}
