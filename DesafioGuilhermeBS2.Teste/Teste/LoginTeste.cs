using DesafioGuilhermeBS2.Teste.Base;
using DesafioGuilhermeBS2.Teste.PageObjects;
using DesafioGuilhermeBS2.Teste.Utils;
using DesafioGuilhermeBS2.Teste.Utils.screenshot;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace DesafioGuilhermeBS2.Teste.Teste
{
    public class LoginTeste 
    {
        private IWebDriver wd;
        private LoginPage log;
        private MetodosComuns mc;
        private screenshot evidenciaTeste;

        [TestCase(Navegadores.GoogleChrome, "guilherme.bento","123456", "acessoSenhaIncorreta")]
        [TestCase(Navegadores.GoogleChrome, "joao.silva","Bm19283746","acessoNomeInocorreto")]
        [TestCase(Navegadores.GoogleChrome, "margherita","","acessoNaoInoformarSenha")]
        [Obsolete]
        public void AcessoNegado(int navegador, string login = null, string password = null, string nomeEvidencia = null)
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
                evidenciaTeste = new screenshot(wd);

                log.GoTo();
                log.Logar(login, password);

                mc.Valida("Your account may be disabled or blocked or the username/password you entered is incorrect.");
                evidenciaTeste.Print(nomeEvidencia);
                mc.Fechar();
            }
            catch (Exception)
            {

                throw;
            }

        }

        [TestCase(Navegadores.Firefox, "guilherme.bento", "Bm19283746", "autenticadoComSucesso")]
        [Obsolete]
        public void UsuarioAutenticado(int navegador, string login = null, string password = null, string nomeEvidencia = null)
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
                evidenciaTeste = new screenshot(wd);

                log.GoTo();
                log.Logar(login, password);

                log.verificaURL("https://mantis-prova.base2.com.br/my_view_page.php");
                evidenciaTeste.Print(nomeEvidencia);
                mc.Fechar();
                
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
