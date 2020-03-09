using OpenQA.Selenium;
using System;
using System.Threading;

namespace DesafioGuilhermeBS2.Teste.Utils
{
    public static class SeleniumExtensions
    {       
        public static void LoadPage(this IWebDriver webDriver, TimeSpan timeToWait, string url)
        {
            webDriver.Manage().Timeouts().PageLoad = timeToWait;
            webDriver.Navigate().GoToUrl(url);
        }
        public static void Esperar(int secondsTimeout)
        {
            var millisecondsTimeout = secondsTimeout * 1000;

            Thread.Sleep(millisecondsTimeout);
        }
    }
}
