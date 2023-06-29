using hs.db;
using hs.entidades;

namespace hs.repositorio
{
    public class ChaveAppRepo
    {
        private readonly ContextoDb _contexto;

        public ChaveAppRepo()
        {

        }

        public List<ChaveApp> BuscarTodos()
        {
            return _contexto.ChaveApp.ToList();
        }
    }
}
