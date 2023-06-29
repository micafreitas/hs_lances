namespace hs.domain
{
    public class RegistroLanceOfertaDto
    {
        public CarteiraClienteDto CarteiraCliente { get; set; }

        public AvisosLanceOfertaDto AvisosLanceOferta { get; set; }

        public bool Sucesso { get; set; }

        public string Mensagem { get; set; }

        public string Erro { get; set; }
    }
}
