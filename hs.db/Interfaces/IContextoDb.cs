using hs.entidades;
using hs.entidades.Views;
using Microsoft.EntityFrameworkCore;

namespace hs.db.Interfaces
{
    public interface IContextoDb
    {
        #region tabelas
        public DbSet<AvisoLance> AvisoLance { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<ChaveApp> ChaveApp { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ContaAcesso> ContaAcesso { get; set; }
        public DbSet<CotaConsorcio> CotaConsorcio { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Parametro> Parametro { get; set; }
        public DbSet<RegistroLance> RegistroLance { get; set; }
        public DbSet<TipoLance> TipoLance { get; set; }
        #endregion

        #region views
        public DbSet<ContaAcessoView> ContaAcessoView { get; set; }
        #endregion

        public void SaveChanges();
    }
}
