using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.IO;
using System.Linq;

namespace DesafioGuilhermeBS2.Teste.Utils.screenshot
{
    public class screenshot
    {
        private readonly IWebDriver _webDriver;
        public screenshot(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
            PageFactory.InitElements(_webDriver, this);
        }

        readonly string sourceFile = @"\DesafioGuilhermeBS2.Teste\DesafioGuilhermeBS2.Teste\Utils\screenshot\";

        public void Print(string nomeEvidencia)
        {
            var contador = 1;
            var diretorioBase = @"C:\QA\Selenium\" + sourceFile;
            var primeiroArquivo = @"C:\QA\Selenium\" + sourceFile + nomeEvidencia + "_" + contador + ".png";
            ITakesScreenshot prt = _webDriver as ITakesScreenshot;
            Screenshot foto = prt.GetScreenshot();

            if (File.Exists(primeiroArquivo))
            {
                var todosArquivos = Directory.GetFiles(diretorioBase).OrderByDescending(a => a).ToList();

                var ultimoArquivo = todosArquivos.FirstOrDefault();

                var contadorExtension = ultimoArquivo.Split('_').LastOrDefault();

                contador = Convert.ToInt32(contadorExtension.Replace(".png", string.Empty)) + 1;
                foto.SaveAsFile(diretorioBase + nomeEvidencia + "_" + contador + ".png", ScreenshotImageFormat.Png);
            }
            else
            {
                foto.SaveAsFile(@"C:\QA\Selenium\" + sourceFile + nomeEvidencia + "_" + contador + ".png", ScreenshotImageFormat.Png);
            }

        }
    }
}
