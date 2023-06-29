using hs.entidades;
using Newtonsoft.Json;

namespace hs.forms.Servicos
{
    public class Api
    {
        private readonly string _urlBase;

        public Api()
        {
            _urlBase = "https://localhost:44346/api/";
        }

        public async Task<ChaveApp> BuscarChaveApp(string chaveApp)
        {
            using (var cliente = new HttpClient())
            {
                var url = $"{_urlBase}ChaveAcesso/BuscarChaveApp?chaveApp={chaveApp}";
                var response = await cliente.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ChaveApp>(content);
                }
                else
                    throw new Exception("Erro ao autenticar App");
            }
        }

        public async Task<List<ContaAcesso>> BuscarContasAcessos(ChaveApp chaveApp)
        {
            using (var cliente = new HttpClient())
            {
                var url = $"{_urlBase}ContaAcesso/BuscarContasAcessos?chaveAppId={chaveApp.Id}";
                var response = await cliente.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var objeto = JsonConvert.DeserializeObject<List<ContaAcesso>>(content);
                    return objeto;
                }
                else
                    throw new Exception("Erro ao autenticar App");
            }
        }
    }
}
