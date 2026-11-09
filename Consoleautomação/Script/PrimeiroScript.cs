
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleAutomacao.Script
{
    public class PrimeiroScript
    {
        public static void Automatizar_Envio_Texto_ComSucesso()
        {
            IWebDriver driverChrome = new ChromeDriver();

            driverChrome.Navigate().GoToUrl(
                "https://www.selenium.dev/selenium/web/web-form.html"
            );

            var titulo = driverChrome.Title;
            Console.WriteLine($"Title: {titulo}");

            driverChrome.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromMilliseconds(500);

            var textBox = driverChrome.FindElement(
                By.Name("my-text")
            );

            var submitButton = driverChrome.FindElement(
                By.TagName("button")
            );

            textBox.SendKeys("Selenium");
            submitButton.Click();

            var message = driverChrome.FindElement(
                By.Id("message")
            );

            var value = message.Text;

            Console.WriteLine($"Message: {value}");
            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();

            driverChrome.Quit();
        }
    }
}
