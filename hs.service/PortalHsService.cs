using hs.domain;
using hs.entidades;
using hs.entidades.Enums;
using hs.service.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace hs.service
{
    public class PortalHsService : IPortalHsService
    {
        public IWebDriver driver { get; set; }
        private readonly IAvisoLanceService _avisoLanceService;
        private readonly IParametroService _parametroService;

        public PortalHsService(IAvisoLanceService avisoLanceService, IParametroService parametroService)
        {
            _avisoLanceService = avisoLanceService;
            _parametroService = parametroService;
        }

        ~PortalHsService()
        {
            driver.Quit();
        }

        public void NavegarPaginaLogin()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var selenimDir = $@"{currentDirectory}\..\..\..\Selenium";

            if (driver == null)
                driver = new ChromeDriver(selenimDir);
        }

        public void AbrirRelatorioCotas()
        {
            NavegarRelatorioVendas();
            NavegarAtendimentoConsorsio();
            ClientesAtivosNaoContemplados();
        }

        public AvisoLance EfetuarLance(CotaConsorcio cotaConsorcio, TipoLanceEnum tipoLance)
        {
            NavegarAtendimento();
            NavegarAtendimentoConsorsio();

            IrFramePrincipal();

            var inputCpfCnpj = driver.FindElement(By.Id("cgc_cpf_cliente"));
            inputCpfCnpj.SendKeys(cotaConsorcio.Cliente.Documento);

            var inputGrupo = driver.FindElement(By.Id("Grupo"));
            inputGrupo.SendKeys(cotaConsorcio.Grupo);

            var inputCota = driver.FindElement(By.Id("Cota"));
            inputCota.SendKeys(cotaConsorcio.Cota);

            var btnLocalizar = driver.FindElement(By.Name("Button"));
            btnLocalizar.Click();

            // Link Lance Oferta
            var lanceOferta = driver.FindElement(By.LinkText("Lance Oferta"));
            lanceOferta.Click();

            var idLanceFixo = tipoLance == TipoLanceEnum.LanceFixo ? "tipo_lance_fixo" : "tipo_seg_lance_fixo";
            var radioLanceFixo = driver.FindElement(By.Id(idLanceFixo));
            radioLanceFixo.Click();

            // Calcular Lance
            var btnCalcularLance = driver.FindElement(By.Id("Altera"));

            if (btnCalcularLance.Enabled)
            {
                btnCalcularLance.Click();

                var btnConfirmaLance = driver.FindElement(By.Id("Confirma"));
                btnConfirmaLance.Click();

                IrFramePrincipal();
            }

            return _avisoLanceService.BuscarAvisoNaPagina(driver.PageSource);
        }

        public IList<CarteiraClienteDto> ExtrairDadosRelatorios()
        {
            var currentWindowHandle = driver.CurrentWindowHandle;
            foreach (var windowHandle in driver.WindowHandles)
            {
                if (windowHandle != currentWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }

            var carteiraCliente = ExtrairListaClientes(PageSourceToList());

            driver.SwitchTo().Window(currentWindowHandle);

            return carteiraCliente;
        }


        public string PageSource()
        {
            return driver.PageSource;
        }

        public List<string> PageSourceToList()
        {
            return driver.PageSource.Split("\n").ToList();
        }

        public void Logar(ContaAcesso contaAcesso)
        {
            driver.Navigate().GoToUrl("http://consweb.hsconsorcio.com.br/");

            var iframe = driver.FindElement(By.TagName("iframe"));
            driver.SwitchTo().Frame(iframe);

            var inputLogin = driver.FindElement(By.Id("j_username"));
            inputLogin.SendKeys(contaAcesso.Login);

            var inputSenha = driver.FindElement(By.Id("j_password"));
            inputSenha.SendKeys(contaAcesso.Senha);

            var btnLogin = driver.FindElement(By.Name("btnLogin"));
            btnLogin.Click();
        }

        private void NavegarAtendimento()
        {
            driver.SwitchTo().DefaultContent();

            var iframe = driver.FindElement(By.TagName("iframe"));
            driver.SwitchTo().Frame(iframe);

            var iframePrincipal = driver.FindElement(By.Name("topFrame"));
            driver.SwitchTo().Frame(iframePrincipal);

            var atendimentoLink = driver.FindElement(By.XPath("/html/body/table/tbody/tr[2]/td/table/tbody/tr/td[3]/b/div/font/a"));
            atendimentoLink.Click();
        }

        private void NavegarFramePrincipal()
        {
            driver.SwitchTo().DefaultContent();
            var iframe = driver.FindElement(By.TagName("iframe"));
            driver.SwitchTo().Frame(iframe);

            var iframePrincipal = driver.FindElement(By.Name("mainFrame"));
            driver.SwitchTo().Frame(iframePrincipal);

            var iframeCentral = driver.FindElement(By.Name("MainFrame"));
            driver.SwitchTo().Frame(iframeCentral);
        }

        private void NavegarRelatorioVendas()
        {
            var iframeMenu = driver.FindElement(By.Name("topFrame"));
            driver.SwitchTo().Frame(iframeMenu);

            //var relatorioVendasLink = driver.FindElement(By.XPath("/html/body/table/tbody/tr[2]/td/table/tbody/tr/td[6]/b/div/font/a"));
            var relatorioVendasLink = driver.FindElement(By.PartialLinkText("REL. VENDAS"));
            relatorioVendasLink.Click();
        }

        private void NavegarAtendimentoConsorsio()
        {
            driver.SwitchTo().DefaultContent();
            var iframe = driver.FindElement(By.TagName("iframe"));
            driver.SwitchTo().Frame(iframe);

            var iframePrincipal = driver.FindElement(By.Name("mainFrame"));
            driver.SwitchTo().Frame(iframePrincipal);

            var iframeMenu = driver.FindElement(By.Name("LeftFrame"));
            driver.SwitchTo().Frame(iframeMenu);

            var analiseCarteira = driver.FindElement(By.XPath("/html/body/table/tbody/tr[1]/td/table/tbody/tr[3]/td[2]/a"));
            analiseCarteira.Click();
        }

        private void ClientesAtivosNaoContemplados()
        {
            NavegarFramePrincipal();

            var js = (IJavaScriptExecutor)driver;

            var abrirAtivos = (IWebElement)js.ExecuteScript("return document.getElementById('jd1')");
            abrirAtivos.Click();

            var naoContemplados = (IWebElement)js.ExecuteScript("return document.getElementById('sd5')");

            naoContemplados.Click();
        }

        private void IrFramePrincipal()
        {
            driver.SwitchTo().DefaultContent();
            var iframe = driver.FindElement(By.TagName("iframe"));
            driver.SwitchTo().Frame(iframe);

            var iframePrincipal = driver.FindElement(By.Name("mainFrame"));
            driver.SwitchTo().Frame(iframePrincipal);

            var iframeCentral = driver.FindElement(By.Name("MainFrame"));
            driver.SwitchTo().Frame(iframeCentral);
        }

        private IList<CarteiraClienteDto> ExtrairListaClientes(List<string> htmlRelatorioNaoContemplados)
        {
            var carteiras = new List<CarteiraClienteDto>();

            for (int i = 0; i < htmlRelatorioNaoContemplados.Count; i++)
            {
                var linha = htmlRelatorioNaoContemplados[i];

                if (linha.Contains("onclick=\"imprimeExtrato("))
                {
                    var inicio = linha.IndexOf("imprimeExtrato");
                    var fim = linha.IndexOf(");\"", inicio);

                    // var parametrosFuncao = linha.Substring(inicio, fim - inicio);
                    var parametrosFuncao = linha[inicio..fim];
                    parametrosFuncao = parametrosFuncao.Replace("imprimeExtrato(", "");
                    string[] parametros = parametrosFuncao.Split(",");

                    var carteiraCliente = new CarteiraClienteDto()
                    {
                        Documento = parametros[1],
                        Grupo = parametros[2],
                        Cota = parametros[3],
                        Contrato = "",
                        DataContemplacao = null
                    };

                    var linhaNome = htmlRelatorioNaoContemplados[i + 3];
                    carteiraCliente.Nome = linhaNome
                        .Replace("<td height=\"5\" align=\"left\">&nbsp;", "")
                        .Replace("</td>", "")
                        .Replace("\r", "")
                        .Trim();

                    var linhaDataVenda = htmlRelatorioNaoContemplados[i + 4];
                    carteiraCliente.DataVenda = DateTime.Parse(linhaDataVenda
                        .Replace("<td height=\"5\" align=\"center\">&nbsp;", "")
                        .Replace("</td>", "")
                    );

                    var linhaPercentualAPagar = htmlRelatorioNaoContemplados[i + 6];
                    carteiraCliente.PercentualAPagar = decimal.Parse(linhaPercentualAPagar
                        .Replace("<td height=\"5\" colspan=\"8\" align=\"right\">", "")
                        .Replace("&nbsp;&nbsp;&nbsp;&nbsp;</td>", "")
                    // .Replace(",", ".")
                    );

                    carteiras.Add(carteiraCliente);
                }
            }

            return carteiras;
        }
    }
}
