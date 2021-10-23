using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class GoogleSearchSeleniumTests
    {
        private string _goolgleUrl = "https://www.google.com";

        private IWebDriver _driver;

        [SetUp]
        public void TestInitialisation()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();
            _driver = new ChromeDriver(configuration["SeleniumWebDriverPath"]);
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void GoogleSearch_ExpectSuccess()
        {
            _driver.Url = _goolgleUrl;
            IWebElement searchText = _driver.FindElement(By.CssSelector("[name = 'q']"));

            searchText.SendKeys("Google it");
            searchText.SendKeys(Keys.Enter);
        }

        [TearDown]
        public void TestTearDown()
        {
            _driver.Quit();
        }
    }
}