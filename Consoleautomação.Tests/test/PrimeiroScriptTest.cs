
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Consoleautomação.Tests.Test
{
    [TestClass]
    public class PrimeiroScriptTest
    {
        [TestMethod]
        public void TestAutomatizar_Envio_Texto_ComSucesso()
        {
            IWebDriver driver = new ChromeDriver();

            try
            {
                driver.Navigate().GoToUrl(
                    "https://www.selenium.dev/selenium/web/web-form.html"
                );

                var title = driver.Title;
                Assert.AreEqual("Web form", title);

                driver.Manage().Timeouts().ImplicitWait =
                    TimeSpan.FromMilliseconds(500);

                var textBox = driver.FindElement(By.Name("my-text"));
                var submitButton = driver.FindElement(By.TagName("button"));

                textBox.SendKeys("Selenium");
                submitButton.Click();

                var messagemSucesso = driver.FindElement(By.Id("message"));
                var value = messagemSucesso.Text;

                Assert.AreEqual("Received!", value);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
