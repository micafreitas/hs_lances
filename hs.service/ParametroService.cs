using hs.db.Interfaces;
using hs.entidades;
using hs.service.Interfaces;

namespace hs.service
{
    public class ParametroService : ServiceBase, IParametroService
    {
        private IList<Parametro> parametros;
        private AvisoLance avisoLanceCotaNaoPossuiSegundoLance;

        public ParametroService(IContextoDb db) : base(db)
        {
            parametros = _db.Parametro.ToList();
        }

        public AvisoLance BuscarAvisoLanceCotaNaoPossuiSegundoLance()
        {
            if (avisoLanceCotaNaoPossuiSegundoLance == null)
            {
                var id = parametros
                    .Where(x => x.Chave == "AvisoLanceCotaNaoPossuiSegundoLance")
                    .Select(s => s.Valor).FirstOrDefault();

                avisoLanceCotaNaoPossuiSegundoLance = _db.AvisoLance
                    .Where(x => x.Id == Int64.Parse(id))
                    .FirstOrDefault();
            }
                
            return avisoLanceCotaNaoPossuiSegundoLance;
        }

        public int BuscarCompetenciaAtual()
        {
            var diaCorte = 1;
            var parametro = parametros
                .Where(x => x.Chave == "DiaCorteCompetencia")
                .FirstOrDefault();

            if (parametro != null)
                Int32.TryParse(parametro.Valor, out diaCorte);

            var hoje = DateTime.Now.Day;

            if (diaCorte >= hoje || hoje <= 10)
            {
                // Competencia atual == Mês atual
                var d = DateTime.Now;
                return Int32.Parse($"{d.Year}{d.Month.ToString("D2")}");
            }
            else
            {
                // Competencia atual == Próximo mês
                var d = DateTime.Now.AddMonths(1);
                return Int32.Parse($"{d.Year}{d.Month.ToString("D2")}");
            }
        }
    }
}
