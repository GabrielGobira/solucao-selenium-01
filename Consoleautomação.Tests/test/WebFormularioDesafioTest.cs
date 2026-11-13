
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Consoleautomação.Tests.Test
{
    [TestClass]
    [DoNotParallelize]
    public class WebFormularioDesafioTest
    {
        private const string UrlFormulario =
            "https://www.selenium.dev/selenium/web/web-form.html";

        // Abre o navegador e acessa o formulário
        private IWebDriver AbrirFormulario()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(UrlFormulario);

            return driver;
        }

        // Envia o formulário e verifica a confirmação
        private void EnviarEValidarFormulario(IWebDriver driver)
        {
            var espera = new WebDriverWait(
                driver,
                TimeSpan.FromSeconds(15)
            );

            var botaoEnviar = espera.Until(d =>
            {
                var elementos = d.FindElements(
                    By.CssSelector("button[type='submit']")
                );

                if (elementos.Count == 0)
                    return null;

                var botao = elementos[0];

                return botao.Displayed && botao.Enabled
                    ? botao
                    : null;
            });

            // Posiciona o botão no centro da tela
            var js = (IJavaScriptExecutor)driver;

            js.ExecuteScript(
                "arguments[0].scrollIntoView({block: 'center'});",
                botaoEnviar
            );

            // Realiza o clique
            try
            {
                botaoEnviar.Click();
            }
            catch (ElementClickInterceptedException)
            {
                // Alternativa caso outro elemento bloqueie o clique
                js.ExecuteScript(
                    "arguments[0].click();",
                    botaoEnviar
                );
            }

            // Aguarda a página de confirmação
            var mensagem = espera.Until(d =>
            {
                var elementos = d.FindElements(By.Id("message"));

                if (elementos.Count == 0)
                    return null;

                return elementos[0].Displayed
                    ? elementos[0]
                    : null;
            });

            Assert.AreEqual("Received!", mensagem.Text);
        }

        // ==================================================
        // EXERCÍCIO 1 - CADASTRO COMPLETO
        // ==================================================

        [TestMethod]
        public void Exercicio1_CadastroCompleto_DeveEnviarComSucesso()
        {
            IWebDriver driver = AbrirFormulario();

            try
            {
                // Preenche o nome
                var campoNome = driver.FindElement(
                    By.Name("my-text")
                );

                campoNome.SendKeys("Gabriel Gobira de Souza");

                // Preenche uma senha fictícia
                var campoSenha = driver.FindElement(
                    By.Name("my-password")
                );

                campoSenha.SendKeys("Teste@2026Seguro!");

                // Preenche a descrição
                var campoDescricao = driver.FindElement(
                    By.Name("my-textarea")
                );

                campoDescricao.SendKeys(
                    "Estou aprendendo automacao de testes " +
                    "com C#, Selenium WebDriver e MSTest."
                );

                // Verifica o campo somente leitura
                var campoReadonly = driver.FindElement(
                    By.Name("my-readonly")
                );

                Assert.AreEqual(
                    "Readonly input",
                    campoReadonly.GetAttribute("value")
                );

                // Envia e valida
                EnviarEValidarFormulario(driver);
            }
            finally
            {
                driver.Quit();
            }
        }

        // ==================================================
        // EXERCÍCIO 2 - DROPDOWN E DATALIST
        // ==================================================

        [TestMethod]
        public void Exercicio2_DropdownEDatalist_DeveEnviarComSucesso()
        {
            IWebDriver driver = AbrirFormulario();

            try
            {
                // Localiza o dropdown
                var dropdown = new SelectElement(
                    driver.FindElement(By.Name("my-select"))
                );

                // Seleciona a opção Two
                dropdown.SelectByText("Two");

                // Verifica se o valor selecionado é 2
                Assert.AreEqual(
                    "2",
                    dropdown.SelectedOption.GetAttribute("value")
                );

                // Localiza o datalist
                var datalist = driver.FindElement(
                    By.Name("my-datalist")
                );

                // Preenche a cidade
                datalist.SendKeys("Seattle");

                // Valida a cidade
                Assert.AreEqual(
                    "Seattle",
                    datalist.GetAttribute("value")
                );

                // Remove o foco do datalist
                // para fechar possíveis sugestões abertas
                datalist.SendKeys(Keys.Tab);

                // Envia e valida
                EnviarEValidarFormulario(driver);
            }
            finally
            {
                driver.Quit();
            }
        }

        // ==================================================
        // EXERCÍCIO 3 - CHECKBOX, RADIO E COLOR PICKER
        // ==================================================

        [TestMethod]
        public void Exercicio3_EstadosEColorPicker_DeveEnviarComSucesso()
        {
            IWebDriver driver = AbrirFormulario();

            try
            {
                // Verifica se o primeiro checkbox está marcado
                var checkbox1 = driver.FindElement(
                    By.Id("my-check-1")
                );

                Assert.IsTrue(
                    checkbox1.Selected,
                    "O primeiro checkbox deveria estar marcado."
                );

                // Marca o segundo checkbox
                var checkbox2 = driver.FindElement(
                    By.Id("my-check-2")
                );

                if (!checkbox2.Selected)
                {
                    checkbox2.Click();
                }

                Assert.IsTrue(
                    checkbox2.Selected,
                    "O segundo checkbox deveria estar marcado."
                );

                // Seleciona o segundo radio button
                var radio2 = driver.FindElement(
                    By.Id("my-radio-2")
                );

                if (!radio2.Selected)
                {
                    radio2.Click();
                }

                Assert.IsTrue(
                    radio2.Selected,
                    "O segundo radio button deveria estar selecionado."
                );

                // Localiza o seletor de cores
                var colorPicker = driver.FindElement(
                    By.Name("my-colors")
                );

                // Altera a cor para vermelho
                var js = (IJavaScriptExecutor)driver;

                js.ExecuteScript(
                    "arguments[0].value = '#ff0000';" +
                    "arguments[0].dispatchEvent(" +
                    "new Event('input', { bubbles: true }));" +
                    "arguments[0].dispatchEvent(" +
                    "new Event('change', { bubbles: true }));",
                    colorPicker
                );

                // Verifica a alteração da cor
                Assert.AreEqual(
                    "#ff0000",
                    colorPicker.GetAttribute("value")
                );

                // Envia e valida
                EnviarEValidarFormulario(driver);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
