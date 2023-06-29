using hs.db.Interfaces;
using hs.entidades;
using hs.service.Interfaces;

namespace hs.service
{
    public class ChaveAppService : IChaveAppService
    {
        private readonly IContextoDb _db;

        public ChaveAppService(IContextoDb db)
        {
            _db = db;
        }

        public IList<ChaveApp> BuscarChaves()
        {
            return _db.ChaveApp.ToList();
        }

        public ChaveApp BuscarChaveApp(string chave)
        {
            return _db.ChaveApp
                .Where(x => x.Chave == chave)
                .FirstOrDefault();
        }
    }
}
