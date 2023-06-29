using Newtonsoft.Json;

namespace hs.entidades.Views
{
    public class ContaAcessoView
    {
        public int Id { get; }

        public long EmpresaId { get; }

        public long ChaveAppId { get; }

        public string Login { get; }

        public string Senha { get; }

        public bool Ativo { get; }

        public int Competencia { get; }

        public int CotasAtivas { get; }

        public int CotasProcessadas { get; }

        public int CotasAProcessar => CotasAtivas - CotasProcessadas;
    }
}
