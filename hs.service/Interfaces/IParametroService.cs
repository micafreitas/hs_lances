using hs.entidades;

namespace hs.service.Interfaces
{
    public interface IParametroService
    {
        public AvisoLance BuscarAvisoLanceCotaNaoPossuiSegundoLance();

        public int BuscarCompetenciaAtual();
    }
}
