using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DesafioGuilhermeBS2.Teste.PageObjects
{
    class ReportIssuePage
    {
        private IWebDriver driver;
        public ReportIssuePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void inserirDetalhesRelatorio(string categoria, string reprodutibilidade, string gravidade, string prioridade, string selecionarPerfil)
        {
            SelectElement Categoria = new SelectElement(driver.FindElement(By.Name("category_id")));
            Categoria.SelectByText(categoria);

            SelectElement Reprodutibilidade = new SelectElement(driver.FindElement(By.Name("reproducibility")));
            Reprodutibilidade.SelectByText(reprodutibilidade);

            SelectElement Gravidade = new SelectElement(driver.FindElement(By.Name("severity")));
            Gravidade.SelectByText(gravidade);

            SelectElement Prioridade = new SelectElement(driver.FindElement(By.Name("priority")));
            Prioridade.SelectByText(prioridade);

            SelectElement SelecionarPerfil = new SelectElement(driver.FindElement(By.Name("profile_id")));
            SelecionarPerfil.SelectByText(selecionarPerfil);
        }
        public void camposObg(string summary = null, string description = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(180));

            if (!string.IsNullOrEmpty(summary))
            {
                var Resumo = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("summary")));
                Resumo.SendKeys(summary);
            }
            if (!string.IsNullOrEmpty(description))
            {
                var Descricao = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("description")));
                Descricao.SendKeys(description);
            }
        }

        public void ClicarEnviarRelatorio()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
            try
            {
                var EnviarRelatorio = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[class='button']")));
                EnviarRelatorio.Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }
    }
}
