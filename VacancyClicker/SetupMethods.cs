using NLog;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;

namespace VacancyClicker
{
    class SetupMethods
    {
        private EventFiringWebDriver _driver;
        internal static WebDriverWait wait;
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private string localUrl = "https://hh.ru/applicant/resumeview/history?resumeHash=01be9d68ff07e8c2ef0039ed1f663764787741&hhtmFrom=resume_list";


        public SetupMethods(EventFiringWebDriver driver)
        {
            this._driver = driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            _driver.Manage().Window.Maximize();
        }


        public void ActionLogging()
        {
            _driver.FindingElement += (sender, el) => _logger.Trace(el.FindMethod);
            _driver.FindElementCompleted += (sender, el) => _logger.Trace(el.FindMethod + "_FOUND");
            _driver.ElementClicking += (sender, el) => _logger.Trace(el.Element + "_Clicking");
            _driver.ElementClicked += (sender, el) => _logger.Trace(el.Element + "_Clicked");
            _driver.ExceptionThrown += (sender, el) => _logger.Error(el.ThrownException);
        }


        public void ActionWriteLine()
        {
            _driver.FindingElement += (sender, el) => Console.WriteLine(el.FindMethod);
            _driver.FindElementCompleted += (sender, el) => Console.WriteLine(el.FindMethod + "_FOUND");
            _driver.ElementClicking += (sender, el) => Console.WriteLine(el.Element + "_Clicking");
            _driver.ElementClicked += (sender, el) => Console.WriteLine(el.Element + "_Clicked");
            _driver.ExceptionThrown += (sender, el) => Console.WriteLine(el.ThrownException);
        }


        public void GoToUrl(string addressUrl)
        {
            _driver.Navigate().GoToUrl(addressUrl);
            _logger.Info($"Opened url =>{addressUrl}");
        }


        public void GoToLocalUrl()
        {
            _driver.Navigate().GoToUrl(localUrl);
            _logger.Info($"Opened url =>{localUrl}");
        }












    }
}
