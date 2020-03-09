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
        private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);
        
        protected BaseTestFixture(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        public abstract void GoTo();

        protected void GoToPath(string path)
        {
            driver.LoadPage(TimeSpan.FromSeconds(10), url: ($"{Host}{path}"));
            driver.Manage().Window.Maximize();

            var timeouts = driver.Manage().Timeouts();
            timeouts.ImplicitWait = DefaultTimeout;
        }
 

        [Obsolete]
        public void WaitForElementByXPath(string xpath)
        {
            new WebDriverWait(driver, DefaultTimeout).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(xpath)));
        }

        [Obsolete]
        public void WaitForElementById(string id)
        {
            new WebDriverWait(driver, DefaultTimeout).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id(id)));
        }

        [Obsolete]
        public void WaitForElementByName(string name)
        {
            new WebDriverWait(driver, DefaultTimeout).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name(name)));
        }

        [Obsolete]
        public void WaitForElementByCss(string css)
        {
            new WebDriverWait(driver, DefaultTimeout).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("[class='"+ css +"']")));
        }

    }
}
