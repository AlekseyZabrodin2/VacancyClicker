using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;

namespace VacancyClicker
{
    [TestFixture]
    [TestFixture(typeof(ChromeDriver))]

    public class Tests<TWebDriver> where TWebDriver : IWebDriver, new()
    {

        private EventFiringWebDriver _driver;
        private WebElementLocator _webElement;
        private ElementLocator _locator;
        private SetupMethods _setupMethods;
        private ExtensionMethods _extensionMethods;
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        private void ActiveDrivers()
        {
            _driver = new EventFiringWebDriver(new TWebDriver());
            _setupMethods = new SetupMethods(_driver);
            _extensionMethods = new ExtensionMethods(_driver);
            _locator = new ElementLocator();
            _webElement = new WebElementLocator(_driver);
        }

        [SetUp]
        public void Setup()
        {
            ActiveDrivers();

            _logger.Debug($"TestDashboard Lowding in - {_driver.WrappedDriver}");

            _setupMethods.ActionLogging();
            _setupMethods.ActionWriteLine();
            _setupMethods.GoToLocalUrl();

            _logger.Debug("Exiting Setup in TestDashboard");
        }        


        [Test]
        public void FindeVacancyInBelarus()
        {
            var responseButton = _webElement.RespondButton;
            WebDriverWait wait = new(_driver, TimeSpan.FromSeconds(3));

            while (responseButton != null)
            {
                responseButton = _webElement.RespondButton;

                try
                {
                    responseButton.Click();
                    _extensionMethods.Scroll(0, 600);

                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("RespondButton не найдена:" + ex.Message);

                    try
                    {
                        var nextButton = _webElement.NextButton;
                        if (nextButton != null)
                        {
                            _extensionMethods.MoveToElement(nextButton);
                            _extensionMethods.Scroll(0, 100);

                            nextButton.Click();
                            Thread.Sleep(2000);
                            continue;
                        }
                    }
                    catch (Exception exeption)
                    {
                        Console.WriteLine("NextButton не найдена: " + exeption.Message);
                    }
                }
            }
        }

        [Test]
        public void FindeVacancyInRussia()
        {
            var responseButton = _webElement.RespondButton;
            WebDriverWait wait = new(_driver, TimeSpan.FromSeconds(3));

            while (responseButton != null)
            {
                responseButton = _webElement.RespondButton;

                try
                {
                    responseButton.Click();

                    try
                    {
                        var mainWindowHandle = _driver.CurrentWindowHandle;
                        var popupWindowHandle = _driver.WindowHandles.Last();
                        var popUpWindow = _driver.SwitchTo().Window(popupWindowHandle);

                        var anyWayResponseButton = _webElement.AnyWayResponseButton;
                        anyWayResponseButton.Click();

                        _driver.SwitchTo().Window(mainWindowHandle);
                    }
                    catch (Exception)
                    {
                        _extensionMethods.Scroll(0, 600);
                        Thread.Sleep(1000);
                    }

                    _extensionMethods.Scroll(0, 600);
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("RespondButton не найдена:" + ex.Message);

                    try
                    {
                        var nextButton = _webElement.NextButton;
                        if (nextButton != null)
                        {
                            _extensionMethods.MoveToElement(nextButton);
                            _extensionMethods.Scroll(0, 100);

                            nextButton.Click();
                            Thread.Sleep(2000);
                            continue;
                        }
                    }
                    catch (Exception exeption)
                    {
                        Console.WriteLine("NextButton не найдена: " + exeption.Message);
                    }
                }
            }
        }


        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
            _driver.Quit();
        }
    }
}
