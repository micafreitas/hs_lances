using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hs.entidades
{
    [Table("clientes")]
    public class Cliente
    {
        public Cliente()
        {
            DhInclusao = DateTime.Now.ToUniversalTime();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("endereco_id")]
        public long? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("documento")]
        public string Documento { get; set; }

        [Column("apelido")]
        public string? Apelido { get; set; }

        [Column("dt_cadastro")]
        public DateTime? DtCadastro { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("telefone")]
        public string? Telefone { get; set; }

        [Column("dh_inclusao")]
        public DateTime DhInclusao { get; set; }

        [Column("dh_alteracao")]
        public DateTime? DhAlteracao { get; set; }

        public ICollection<CotaConsorcio> CotaConsorcio { get; set; }
    }
}
