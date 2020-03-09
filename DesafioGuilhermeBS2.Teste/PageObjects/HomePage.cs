using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DesafioGuilhermeBS2.Teste.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;
        private UnassignedPage unassigned;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Obsolete]
        public void irParaNaoAtribuido(string NumeroNaoAtribuido)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
                var numberUnassigned = wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(NumeroNaoAtribuido)));
                numberUnassigned.Click();
                unassigned = new UnassignedPage(driver);
                unassigned.ValidaDirecionamentoTela(NumeroNaoAtribuido);

            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
                driver.Quit();

            }
        }

        [Obsolete]
        public void irParaInserirDetalhesRelatorio()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
            var clicarDirecionarProblema = wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText("Report Issue")));
            clicarDirecionarProblema.Click();
            Assert.AreEqual(driver.Title, "Report Issue - MantisBT");
        }
    }
}
