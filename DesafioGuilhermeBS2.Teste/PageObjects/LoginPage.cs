using DesafioGuilhermeBS2.Teste.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DesafioGuilhermeBS2.Teste.PageObjects
{
    class LoginPage : BaseTestFixture
    {
        public LoginPage(IWebDriver driver)
            : base(driver)
        {
        }

        [Obsolete]
        public void Logar(string login, string password)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(180));

            var loginName = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("username")));
            var keyWord = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("password")));
            loginName.SendKeys(login);
            keyWord.SendKeys(password);

            try
            {
                var enterBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[class ='button']")));
                enterBtn.Click();
            }
            catch (NoSuchElementException)
            {

                Assert.Fail();
            }

        }
        public void verificaURL(string url)
        {
            if (!driver.Url.Equals(url))
            {
                Sair();
                throw new StaleElementReferenceException("Essa não é página inicial e o caso de teste não será executado");
            }
        }

        public void verificarTitulo(string titulo)
        {
            Assert.AreEqual(driver.Title, "My View - MantisBT");
        }

        public void Sair()
        {
            driver.Quit();
            driver = null;
        }

        public override void GoTo()
        {
            GoToPath("#/Login");
        }
    }
}
