using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hs.entidades
{
    [Table("enderecos")]
    public class Endereco
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("cidade_id")]
        public long CidadeId { get; set; }
        public Cidade Cidade { get; set; }

        [Column("logradouro")]
        public string Logradouro { get; set; }

        [Column("numero")]
        public string Numero { get; set; }

        [Column("bairro")]
        public string? Bairro { get; set; }

        [Column("referencia")]
        public string? Referencia { get; set; }

        [Column("cep")]
        public string Cep { get; set; }
    }
}
