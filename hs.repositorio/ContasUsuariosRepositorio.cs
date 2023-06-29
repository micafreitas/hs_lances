using hs.domain;

namespace hs.repositorio
{
    public class ContasUsuariosRepositorio
    {
        public IList<ContaAcessoDto> GetContasUsuarios()
        {
            var contas = new List<ContaAcessoDto>();
            contas.Add(new ContaAcessoDto()
                {
                    ContaUsuario = 2413,
                    Senha = "7unita2023"
                }
            );

            return contas;
        }
    }
}
