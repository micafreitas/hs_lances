namespace hs.util
{
    public interface INotificacaoForm
    {
        public void OnMensagem(string mensagem);

        public void OnProcessoIniciado();

        public void OnProcessoFinalizado();
    }
}
