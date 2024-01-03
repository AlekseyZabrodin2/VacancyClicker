using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyClicker
{
    class WebElementLocator
    {
        private EventFiringWebDriver _driver;
        internal static WebDriverWait _wait;
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private ExtensionMethods _extensionMethods;


        public WebElementLocator(EventFiringWebDriver driver)
        {
            this._driver = driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }





        public IWebElement RespondButton => _driver.FindElement(By.PartialLinkText("Откликнуться"));

        public IWebElement NextButton => _driver.FindElement(By.PartialLinkText("дальше"));

    }
}
