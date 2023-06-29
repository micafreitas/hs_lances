using hs.service.Interfaces;
using hs.forms;
using Microsoft.Extensions.DependencyInjection;
using hs.entidades;
using System.ComponentModel;
using hs.util;
using hs.forms.Servicos;
using Newtonsoft.Json;
using hs.service;

namespace Hs
{
    public partial class Principal : Form, INotificacaoForm
    {
        private readonly IChaveAppService _chaveAppService;
        private readonly ILanceService _lanceService;
        private ChaveApp chaveApp;

        private readonly IContaAcessoService _contaAcessoService;

        private IList<CotaUC> cotasUC;

        public Principal(ServiceProvider service)
        {
            hs.forms.Properties.Settings.Default.CHAVE_APP = "ce85bc81-9e9c-404a-834e-bfe84de78e90";
            hs.forms.Properties.Settings.Default.Save();

            _contaAcessoService = service.GetService<IContaAcessoService>();
            _chaveAppService = service.GetService<IChaveAppService>();
            _lanceService = service.GetService<ILanceService>();

            InitializeComponent();

            Iniciar();
        }

        private async Task Iniciar()
        {
            var json = @"
[
    {
        'id': 3,
        'empresaId': 1,
        'empresa': null,
        'login': '2413',
        'senha': '7unita2023',
        'ativo': true,
        'contaAcessoView': {
            'id': 3,
            'empresaId': 1,
            'chaveAppId': 1,
            'login': '2413',
            'senha': '7unita2023',
            'ativo': true,
            'competencia': 202305,
            'cotasAtivas': 428,
            'cotasProcessadas': 0,
            'cotasAProcessar': 428
        }
    }
]";
            var obj = JsonConvert.DeserializeObject<List<ContaAcesso>>(json);

            await ValidarChaveAcesso();

            //var contasAcessos = _contaAcessoService.BuscarContasAcesso(chaveApp);
            //await CarregarContasAcesso();
        }

        private async Task CarregarContasAcesso()
        {
            // var contasAcessos = await new Api().BuscarContasAcessos(chaveApp);
            var contasAcessos = _contaAcessoService.BuscarContasAcesso(chaveApp.Id);
            if (!contasAcessos.Any())
            {
                MessageBox.Show("Nenhuma conta encontrada");
                return;
            }

            cotasUC = new List<CotaUC>();
            foreach (var conta in contasAcessos)
                pnContas.Controls.Add(new CotaUC(_lanceService, chaveApp, conta, this));
        }

        private async Task ValidarChaveAcesso()
        {
            string chaveAppLocal = hs.forms.Properties.Settings.Default.CHAVE_APP;

            var api = new Api();
            //chaveApp = await api.BuscarChaveApp(chaveAppLocal);
            try
            {
                chaveApp = _chaveAppService.BuscarChaveApp(chaveAppLocal);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            await CarregarContasAcesso();

            if (chaveApp == null)
            {
                MessageBox.Show("Chave não encotrada");
                AbrirPopUpSetarChave();
                ValidarChaveAcesso();
            }

            return;

            chaveAppLocal = hs.forms.Properties.Settings.Default.CHAVE_APP;
            if (string.IsNullOrEmpty(chaveAppLocal))
            {
                AbrirPopUpSetarChave();
                ValidarChaveAcesso();
            }

            chaveApp = _chaveAppService.BuscarChaveApp(chaveAppLocal);
            if (chaveApp == null)
            {
                MessageBox.Show("Chave não encotrada");
                AbrirPopUpSetarChave();
                ValidarChaveAcesso();
            }

            if (chaveApp!.DhBloqueio.HasValue)
            {
                MessageBox.Show("Chave bloqueada");
                Application.Exit();
            }

            //if (chaveApp.DhExpiracao.HasValue)
            //{
            //    MessageBox.Show("Chave expirada");
            //    return false;
            //}
        }

        private void AbrirPopUpSetarChave()
        {
            var popUp = new SetarChaveAppForm(_chaveAppService);
            popUp.Show();
        }



        private void btnProcessarTodos_Click(object sender, EventArgs e)
        {
            pnContas.Enabled = false;

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkCompleted);

            // Inicia a execução da tarefa em segundo plano
            worker.RunWorkerAsync();
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var cota in cotasUC)
                cota.EfetuarLances();
        }

        private void WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pnContas.Enabled = true;
            MessageBox.Show("Todas as contas foram processadas", "Sistema de Lances", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void OnMensagem(string mensagem)
        {
            MessageBox.Show(mensagem);
        }

        public void OnProcessoIniciado()
        {
            this.Invoke(new DesabilitarComponentesDelegate(DesabilitarComponentes), new object[] { pnContas });
        }

        public void OnProcessoFinalizado()
        {
            this.Invoke(new HabilitarComponentesDelegate(HabilitarComponentes), new object[] { pnContas });
        }

        private delegate void DesabilitarComponentesDelegate(Panel panel);
        private void DesabilitarComponentes(Panel panel)
        {
            panel.Enabled = false;
            btnProcessarTodos.Enabled = false;
        }

        private delegate void HabilitarComponentesDelegate(Panel panel);
        private void HabilitarComponentes(Panel panel)
        {
            panel.Enabled = true;
            btnProcessarTodos.Enabled = true;
        }

    }
}