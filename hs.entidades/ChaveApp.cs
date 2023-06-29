using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hs.entidades
{
    [Table("chaves_app")]
    public class ChaveApp
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("chave")]
        public string Chave { get; set; }

        [Column("dh_inclusao")]
        public DateTime DhInclusao { get; set; }

        [Column("dh_vinculo")]
        public DateTime? DhVinculo { get; set; }

        [Column("dh_ultimo_acesso")]
        public DateTime? DhUltimoAcesso { get; set; }

        [Column("dh_bloqueio")]
        public DateTime? DhBloqueio { get; set; }


        public Empresa Empresa { get; set; }

        ICollection<RegistroLance> LancesEfetuados { get; set; }

        //[Column("dh_expiracao")]
        //public DateTime? DhExpiracao { get; set; }

    }
}