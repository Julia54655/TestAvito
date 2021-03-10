using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace AuthorizationPageAvitoTest
{
    public static class Data
    {
       public static string login = "";
        public static string password = "";
    }
    public class Tests
    {
        public void Click(By buttonName)
        {
            var button = driver.FindElement(buttonName);
            button.Click();
        }
        public void Input(By inputName, string key)
        {
            var input = driver.FindElement(inputName);
            input.SendKeys(key);
        }

        private IWebDriver driver;
        private readonly By signInButton = By.XPath(".//*[text()='Вход и регистрация']/..");
        private readonly By loginInputButton = By.XPath(".//input[@name='login']");
        private readonly By passwordInputButton = By.XPath(".//input[@name='password']");
        private readonly By checkButton = By.XPath(".//*[text()='Запомнить пароль']/..");
        private readonly By submitButton = By.XPath(".//*[text()='Войти']/..");

        [SetUp]
        public void Setup()
        {
            driver =new  OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://www.avito.ru");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            Click(signInButton);

            Input(loginInputButton, Data.login);

            Input(passwordInputButton, Data.password);

            Click(checkButton);

            Click(submitButton);
            Thread.Sleep(1000);

           
        }

        [TearDown]

        public void TearDown()
        {
            driver.Quit();

        }

        
    }
}