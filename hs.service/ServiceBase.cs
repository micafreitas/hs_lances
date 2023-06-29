using hs.db.Interfaces;

namespace hs.service
{
    public class ServiceBase
    {
        protected IContextoDb _db;

        public ServiceBase(IContextoDb db)
        {
            _db = db;
        }
    }
}
