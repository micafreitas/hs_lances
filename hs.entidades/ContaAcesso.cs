using hs.entidades.Views;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace hs.entidades
{
    [Table("contas_acessos")]
    public class ContaAcesso
    {
        public ContaAcesso()
        { }

        [Key]
        [Column("id")]
        [JsonProperty("id")]
        public long Id { get; set; }

        [Column("empresa_id")]
        public long EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; }

        [NotMapped]
        //[JsonPropertyName("contaAcessoView")]
        //[JsonProperty("contaAcessoView")]
        public ContaAcessoView ContaAcessoView { get; set; }
    }
}
