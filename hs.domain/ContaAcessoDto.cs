namespace hs.domain
{
    public class ContaAcessoDto
    {
        public int ContaUsuario { get; set; }

        public string Senha { get; set; }

        public int ContasAtivas { get; set; }

        public int ContasProcessadasAnteriormente { get; set; }

        public int ContasAProcessar { get; set; }
    }
}
