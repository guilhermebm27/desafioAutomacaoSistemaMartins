using DesafioGuilhermeBS2.Teste.PageObjects;
using DesafioGuilhermeBS2.Teste.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace DesafioGuilhermeBS2.Teste.Teste
{
    public class AtribuirProjeto
    {
        private IWebDriver wd;
        private LoginPage log;
        private MetodosComuns mc;
        private HomePage paginaInicial;
        private UnassignedPage detalhesProjeto;
        private TestEvidence evidenciaTeste;

        [TestCase(Navegadores.GoogleChrome, "guilherme.bento", "Bm19283746", "3658", "testeBase2", "desafio de teste base2", "desafio de teste base2")]
        [TestCase(Navegadores.GoogleChrome, "guilherme.bento", "Bm19283746", "3657", "Teste", "desafio de teste base2 realizado no dia 06/03", "evidencia desafio 0603")]
        [Obsolete]
        public void AtribuirProjetoBs2(int navegador, string login, string password, string NumeroNaoAtribuido, string adiconarTag, string adicionarNotaDoProblema, string screenShotName)
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
                mc = new MetodosComuns(wd);
                paginaInicial = new HomePage(wd);
                detalhesProjeto = new UnassignedPage(wd);
                evidenciaTeste = new TestEvidence(wd);

                log.GoTo();
                log.Logar(login, password);
                paginaInicial.irParaNaoAtribuido(NumeroNaoAtribuido);
                detalhesProjeto.ValidaDirecionamentoTela(NumeroNaoAtribuido);
                detalhesProjeto.PreencherFormulario(adiconarTag);
                detalhesProjeto.anexarArquivo();
                detalhesProjeto.adicionarNota(adicionarNotaDoProblema);
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
