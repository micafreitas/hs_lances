using hs.db.Interfaces;
using hs.entidades;
using hs.entidades.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql;

namespace hs.db
{
    public class ContextoDb : DbContext, IContextoDb
    {
        public ContextoDb()
        { }

        public ContextoDb(DbContextOptions<ContextoDb> options) : base(options)
        { }

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseNpgsql("Host=191.252.111.53;Database=hml_spartan;Username=micael;Password=332211;Search Path=automacao");
                optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=332211;Search Path=automacao");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "pt_BR.UTF-8");

            modelBuilder.Entity<ChaveApp>()
                .HasOne(a => a.Empresa)
                .WithOne(b => b.ChaveApp)
                .HasForeignKey<Empresa>(b => b.ChaveAppId);

            modelBuilder.Entity<ContaAcessoView>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("v_contas_acessos");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.EmpresaId).HasColumnName("empresa_id");
                entity.Property(e => e.ChaveAppId).HasColumnName("chave_app_id");
                entity.Property(e => e.Login).HasColumnName("login");
                entity.Property(e => e.Senha).HasColumnName("senha");
                entity.Property(e => e.Ativo).HasColumnName("ativo");
                entity.Property(e => e.Competencia).HasColumnName("competencia");
                entity.Property(e => e.CotasAtivas).HasColumnName("cotas_ativas");
                entity.Property(e => e.CotasProcessadas).HasColumnName("cotas_processadas");
            });
        }


        void IContextoDb.SaveChanges()
        {
            SaveChanges();
        }
    }
}