using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hs.entidades
{
    [Table("cidades")]
    public class Cidade
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("uf")]
        public string Uf { get; set; }

        [Column("codigo_ibge")]
        public int CodigoIbge { get; set; }

        public ICollection<Endereco> Enderecos { get; set; }
    }
}
