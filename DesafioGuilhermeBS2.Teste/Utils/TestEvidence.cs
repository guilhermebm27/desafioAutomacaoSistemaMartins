using OpenQA.Selenium;
using System;
using System.IO;

namespace DesafioGuilhermeBS2.Teste.Utils
{
    public class TestEvidence
    {
        private readonly IWebDriver driver;
        public TestEvidence(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string Capture(string screenShotName)
        {

            string localpath = "";
            try
            {
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();

                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Defect_Screenshots\\");
                string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "\\Defect_Screenshots\\" + screenShotName + ".png";
                localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return localpath;

        }
    }
}
