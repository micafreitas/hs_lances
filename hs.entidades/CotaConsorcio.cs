using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hs.entidades
{
    [Table("cotas_consorcios")]
    public class CotaConsorcio
    {
        public CotaConsorcio()
        {
            DhInclusao = DateTime.Now.ToUniversalTime();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("conta_acesso_id")]
        public long ContaAcessoId { get; set; }
        public ContaAcesso ContaAcesso { get; set; }

        [Column("cliente_id")]
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Column("cota")]
        public string Cota { get; set; }

        [Column("grupo")]
        public string Grupo { get; set; }

        [Column("contrato")]
        public string? Contrato { get; set; }

        [Column("dt_venda")]
        public DateTime? DtVenda { get; set; }

        [Column("valor")]
        public decimal? Valor { get; set; }

        [Column("percentual_pagar")]
        public decimal? PercentualPagar { get; set; }

        [Column("dh_atualizacao_percentual_pagar")]
        public DateTime? DhAtualizacaoPercentualPagar { get; set; }        

        [Column("dt_contemplacao")]
        public DateTime? DtContemplacao { get; set; }

        [Column("dt_cancelamento")]
        public DateTime? DtCancelamento { get; set; }

        [Column("dh_inclusao")]
        public DateTime DhInclusao { get; set; }

        [Column("dh_alteracao")]
        public DateTime? DhAlteracao { get; set; }

        [Column("dh_exclusao")]
        public DateTime? DhExclusao { get; set; }

        public ICollection<RegistroLance> RegistrosLances { get; set; }
    }
}
