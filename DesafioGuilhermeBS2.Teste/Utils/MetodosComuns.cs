using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace DesafioGuilhermeBS2.Teste.Utils
{
    class MetodosComuns
    {
        private IWebDriver driver;
        public MetodosComuns(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void Fechar()
        {
            driver.Quit();
        }

        public bool Valida(string assert)
        {
            bool achouTela = driver.PageSource.Contains(assert);
            return achouTela;
        }
    }
}
