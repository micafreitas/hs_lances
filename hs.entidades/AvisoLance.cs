using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hs.entidades
{
    [Table("avisos_lances")]
    public class AvisoLance
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("aviso")]
        public string Aviso{ get; set; }

        [Column("mensagem")]
        public string? Mensagem { get; set; }

        [Column("lance_efetuado")]
        public bool LanceEfetuado { get; set; }

        [Column("lance_efetuado_anteriormente")]
        public bool LanceEfetuadoAnteriormente { get; set; }

        [Column("restricao_lance")]
        public bool RestricaoLance { get; set; }

        [Column("erro")]
        public bool Erro { get; set; }

        ICollection<RegistroLance> RegistrosLances { get; set; }
    }
}
