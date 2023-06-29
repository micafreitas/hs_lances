using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hs.entidades
{
    [Table("tipos_lances")]
    public class TipoLance
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        ICollection<RegistroLance> RegistrosLances { get; set; }
    }
}
