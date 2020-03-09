using DesafioGuilhermeBS2.Teste.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DesafioGuilhermeBS2.Teste.Base
{
    public abstract class BaseTestFixture
    {
        protected IWebDriver driver;
        public const string Host = "http://mantis-prova.base2.com.br";
        
        protected BaseTestFixture(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        public abstract void GoTo();

        protected void GoToPath(string path)
        {
            driver.LoadPage(TimeSpan.FromSeconds(10), url: ($"{Host}{path}"));
            driver.Manage().Window.Maximize();
        }      
    }
}
