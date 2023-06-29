using hs.entidades;

namespace hs.domain
{
    public class CarteiraClienteDto
    {
        public string Documento { get; set; }

        public string Nome { get; set; }

        public string Cota { get; set; }

        public string Grupo { get; set; }

        public string Contrato { get; set; }

        public DateTime DataVenda { get; set; }

        public DateTime? DataContemplacao { get; set; }

        public decimal PercentualAPagar { get; set; }

        public ContaAcesso contaAcesso { get; set; }
    }
}
