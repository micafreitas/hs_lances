using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hs.entidades
{
    [Table("registros_lances")]
    public class RegistroLance
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("chave_app_id")]
        public long ChaveAppId { get; set; }
        public ChaveApp ChaveApp { get; set; }

        [Column("cota_consorcio_id")]
        public long CotaConsorcioId { get; set; }
        public CotaConsorcio CotaConsorcio { get; set; }

        [Column("aviso_lance_id")]
        public long AvisoLanceId { get; set; }
        public AvisoLance AvisoLance { get; set; }

        [Column("tipo_lance_id")]
        public long TipoLanceId { get; set; }
        public TipoLance TipoLance { get; set; }        

        [Column("dh_lance")]
        public DateTime DhLance { get; set; }

        [Column("competencia")]
        public int Competencia { get; set; }

        [Column("sucesso")]
        public bool Sucesso { get; set; }

        [Column("msg_aviso")]
        public string? MsgAviso { get; set; }

        [Column("msg_erro")]
        public string? MsgErro { get; set; }

        [Column("html_pagina")]
        public string HtmlPagina { get; set; }
    }
}
