using DesafioGuilhermeBS2.Teste.PageObjects;
using DesafioGuilhermeBS2.Teste.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace DesafioGuilhermeBS2.Teste.Teste
{
    public class InformarProblema
    {
        private IWebDriver wd;
        private LoginPage log;
        private HomePage paginaInicial;
        private MetodosComuns mc;
        private ReportIssuePage reportarProblema;
        private TestEvidence evidenciaTeste;

        [TestCase(Navegadores.GoogleChrome, "guilherme.bento", "Bm19283746", "[All Projects] Teste", "random", "text", "low", "x86 LINUX SOLARIS","teste realziado no dia 09/03","teste bsase2", "InserirDetalhesRelatorioComSucesso")]
        [Obsolete]
        public void InserirDetalhesRelatorioComSucesso(int navegador, string login, string password, string categoria, string reprodutibilidade, string gravidade, string prioridade, string selecionarPerfil,string summary, string description, string screenShotName)
        {
            try
            {
                switch (navegador)
                {
                    case Navegadores.GoogleChrome:
                        wd = new ChromeDriver();
                        break;
                    case Navegadores.Firefox:
                        wd = new FirefoxDriver();
                        break;
                    default:
                        break;
                }

                log = new LoginPage(wd);
                paginaInicial = new HomePage(wd);
                reportarProblema = new ReportIssuePage(wd);
                mc = new MetodosComuns(wd);
                evidenciaTeste = new TestEvidence(wd);

                log.GoTo();
                log.Logar(login, password);
                paginaInicial.irParaInserirDetalhesRelatorio();
                reportarProblema.inserirDetalhesRelatorio(categoria, reprodutibilidade, gravidade, prioridade, selecionarPerfil);
                reportarProblema.camposObg(summary, description);
                reportarProblema.ClicarEnviarRelatorio();
                mc.Valida("Operation successful.");

                evidenciaTeste.Capture(screenShotName);
                mc.Fechar();
            }
            catch (Exception)
            {

                throw;
            }

        }
        [TestCase(Navegadores.GoogleChrome, "guilherme.bento", "Bm19283746", "ErroDeixardePreencherCampoResumo", "testeBase2", null)]
        [TestCase(Navegadores.GoogleChrome, "guilherme.bento", "Bm19283746", "ErroDeixardePreencherCampoDescricao", null, "testeBase2")]
        [Obsolete]
        public void deixardePreenchercamposObrigatorios(int navegador, string login, string password, string screenShotName , string summary = null, string description = null)
        {
            try
            {
                switch (navegador)
                {
                    case Navegadores.GoogleChrome:
                        wd = new ChromeDriver();
                        break;
                    case Navegadores.Firefox:
                        wd = new FirefoxDriver();
                        break;
                    default:
                        break;
                }

                log = new LoginPage(wd);
                paginaInicial = new HomePage(wd);
                reportarProblema = new ReportIssuePage(wd);
                mc = new MetodosComuns(wd);
                evidenciaTeste = new TestEvidence(wd);

                log.GoTo();
                log.Logar(login, password);
                paginaInicial.irParaInserirDetalhesRelatorio();
                reportarProblema.camposObg(summary, description);
                reportarProblema.ClicarEnviarRelatorio();
                mc.Valida("A necessary field  was empty. Please recheck your inputs.");

                evidenciaTeste.Capture(screenShotName);
                mc.Fechar();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
