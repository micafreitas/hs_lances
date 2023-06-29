using hs.entidades;
using hs.entidades.Views;
using hs.service;
using hs.service.Interfaces;
using hs.util;
using System.ComponentModel;

namespace hs.forms
{
    public partial class CotaUC : UserControl, INotificacaoForm, INotificacaoAndamento
    {
        private readonly ChaveApp _chaveApp;
        private readonly ILanceService _lanceService;
        private readonly ContaAcesso _contaAcesso;
        private readonly INotificacaoForm _notificacaoForm;

        public CotaUC(ILanceService lanceService, ChaveApp chaveApp, ContaAcesso contaAcesso, INotificacaoForm notificacaoForm)
        {
            InitializeComponent();

            _chaveApp = chaveApp;
            _lanceService = lanceService;
            _contaAcesso = contaAcesso;
            _notificacaoForm = notificacaoForm;

            PrintarDados();
        }

        private void PrintarDados()
        {
            lblConta.Text = _contaAcesso.ContaAcessoView.Login;
            lblContasAtivas.Text = _contaAcesso.ContaAcessoView.CotasAtivas.ToString();
            lblCotasProcessadasAnteriormente.Text = _contaAcesso.ContaAcessoView.CotasProcessadas.ToString();
            lblCotasAProcessar.Text = _contaAcesso.ContaAcessoView.CotasAProcessar.ToString();
            //lblCompetenciaProcessamento.Text =
            //    $"{_contaAcesso.ContaAcessoView.Competencia.ToString().Substring(4, 2)}/{_contaAcesso.ContaAcessoView.Competencia.ToString().Substring(0, 4)}";
        }

        private void btnEfetuarLances_Click(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkCompleted);

            // Inicia a execução da tarefa em segundo plano
            worker.RunWorkerAsync();
        }

        public void EfetuarLances()
        {
            try
            {
                _notificacaoForm.OnProcessoIniciado();

                _lanceService.ExtrairClientesCotas(_chaveApp, _contaAcesso, this);

                // _lanceService.BuscarIndicadoresAtualizados(_chaveApp, _contaAcesso, this);

                _lanceService.EfetuarLances(_chaveApp, _contaAcesso, this, this);
            }
            catch (Exception ex)
            {
                try
                {

                }
                catch 
                {
                    // TODO Gravar erro de execução no DB
                }

                MessageBox.Show(
                    "Erro no processo, por favor reinicialize o programa e inicie o processo novamente", 
                    "Sistema de Lances", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
            }
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            EfetuarLances();
        }

        private void WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _notificacaoForm.OnProcessoFinalizado();
        }

        public void OnMensagem(string mensagem)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(OnMensagem), mensagem);
                return;
            }

            lblProcessoAtual.Text = mensagem;
        }

        public void OnProcessoIniciado()
        {
            throw new NotImplementedException();
        }

        public void OnProcessoFinalizado()
        {
            throw new NotImplementedException();
        }

        public void OnAndamento(int atual, int total)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int, int>(OnAndamento), atual, total);
                return;
            }

            prgProcesso.Maximum = total;
            prgProcesso.Value = atual;

            lblCotasAProcessar.Text = total.ToString();
        }
    }
}
