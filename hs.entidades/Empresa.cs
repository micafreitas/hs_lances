using hs.entidades.Views;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hs.entidades
{
    [Table("empresas")]
    public class Empresa
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("chave_app_id")]
        public long ChaveAppId { get; set; }

        public ChaveApp ChaveApp { get; set; }

        public ICollection<ContaAcesso> ContaAcesso { get; set; }
        // public ICollection<ContaAcessoView> ContaAcessoView { get; set; }
    }
}
