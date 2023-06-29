using hs.db.Interfaces;
using hs.domain;
using hs.entidades;
using hs.service.Interfaces;

namespace hs.service
{
    public class ClienteService : ServiceBase, IClienteService
    {
        public ClienteService(IContextoDb db) : base(db)
        { }

        public Cliente Merge(ContaAcesso contaAcesso, CarteiraClienteDto contaCliente)
        {
            var clienteDb = _db.Cliente
                .Where(x => x.Documento == contaCliente.Documento)
                .FirstOrDefault();

            if (clienteDb != null)
                return clienteDb;

            clienteDb = new Cliente()
            {
                Documento = contaCliente.Documento,
                Nome = contaCliente.Nome
            };

            _db.Cliente.Add(clienteDb);

            return clienteDb;
        }
    }
}
