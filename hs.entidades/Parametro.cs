using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hs.entidades
{
    [Table("parametros")]
    public class Parametro
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("chave")]
        public string Chave { get; set; }

        [Column("valor")]
        public string Valor { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }
    }
}
