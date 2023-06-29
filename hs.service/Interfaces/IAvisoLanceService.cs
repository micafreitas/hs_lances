using hs.entidades;

namespace hs.service.Interfaces
{
    public interface IAvisoLanceService
    {
        void CarregarAvisos();

        AvisoLance BuscarAvisoSucesso();

        AvisoLance BuscarAvisoNaPagina(string pageSource);

        AvisoLance BuscarAvisoErro();

        AvisoLance BuscarAvisoFalhaNaoMapeada();
    }
}
