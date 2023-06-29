using hs.service.Interfaces;

namespace hs.forms
{
    public partial class SetarChaveAppForm : Form
    {
        private readonly IChaveAppService _chaveAppService;
        public SetarChaveAppForm(IChaveAppService chaveAppService)
        {
            InitializeComponent();

            _chaveAppService = chaveAppService;
        }

        private void btnSetarChave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chave não informada");
            this.Close();
        }
    }
}
