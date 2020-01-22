using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TesteBase2
{
    [TestFixture]
    public class Test
    { 
        public static IWebDriver driver;

        [Test]
        public void AbrindoSite()
        {
            string website = "http://mantis-prova.base2.com.br";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(website);
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void Logando()
        {
            string usuario = "thiago.damiany";
            string senha = "td123456";
            var logando = driver.FindElement(By.XPath("//html/body/div[3]/form/table/tbody/tr[2]/td[2]/input"));
            logando.SendKeys(usuario);
            logando = driver.FindElement(By.XPath("/html/body/div[3]/form/table/tbody/tr[3]/td[2]/input"));
            logando.SendKeys(senha);
            logando = driver.FindElement(By.XPath("/html/body/div[3]/form/table/tbody/tr[6]/td/input"));
            logando.Click();
            var logado = driver.FindElement(By.XPath("/html/body/table[1]/tbody/tr/td[1]"));
            logado.Text.Contains(usuario);
        }

        [Test]
        public void InserindoBug()
        {
            var issue = driver.FindElement(By.PartialLinkText("/bug_report_page.php"));
            //issue.Text.Contains("Report Issue");
            issue.Click();
            issue.FindElement(By.XPath("//input[@value='bug_report_page.php']"));
            issue.Text.Equals("Select Project");
        }
        [TearDown]
        public void TearDown()
        {
           // driver.Quit();
        }
    }
}
