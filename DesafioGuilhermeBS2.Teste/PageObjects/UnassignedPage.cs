using DesafioGuilhermeBS2.Teste.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DesafioGuilhermeBS2.Teste.PageObjects
{
     class UnassignedPage
    {
        private MetodosComuns mc;
        private IWebDriver driver;

        public UnassignedPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ValidaDirecionamentoTela(string assertNumeroProjeto)
        {
            mc = new MetodosComuns(driver);
            mc.Valida(assertNumeroProjeto);
        }

        [Obsolete]
        public void PreencherFormulario(string adiconarTag)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(180));

            var AdiconarTag = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("tag_string")));
            var addTag = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[class='button']")));

            AdiconarTag.SendKeys(adiconarTag);
            addTag.Click();
        }

        public void anexarArquivo()
        {
            string filePath = @"C:\QA\PdfTeste\teste33.pdf";

            IWebElement UploadArquivo = driver.FindElement(By.Id("ufile[]"));
            UploadArquivo.SendKeys(filePath);
        }

        [Obsolete]
        public void adicionarNota(string adicionarNotaDoProblema)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
            var InformarDadosParaNota = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("bugnote_text")));
            var AdicionarNota = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='bugnote_add_open']/form/table/tbody/tr[3]/td/input")));
            
            InformarDadosParaNota.SendKeys(adicionarNotaDoProblema);
            AdicionarNota.Click();
        }
    }
}
