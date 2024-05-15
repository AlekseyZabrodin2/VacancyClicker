using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V122.Network;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace VacancyClicker
{
    [TestFixture]

    [TestFixture(typeof(ChromeDriver))]

    public class Tests<TWebDriver> where TWebDriver : IWebDriver, new()
    {

        private EventFiringWebDriver _driver;
        //private LoginCredential _loginCredential;
        //private DashboardPageLocator _dashboardPageLocator;
        //private DashboardWebElement _dashboardWebElement;
        //private DashboardButtonClick _dashboardButtonClick;
        //private GettingValueMethods _gettingValueMethods;
        //private WaitMethods _waitMethods;

        private WebElementLocator _webElement;
        private ElementLocator _locator;
        private SetupMethods _setupMethods;
        private ExtensionMethods _extensionMethods;
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        private void ActiveDrivers()
        {
            _driver = new EventFiringWebDriver(new TWebDriver());
            _setupMethods = new SetupMethods(_driver);
            //_loginCredential = new LoginCredential(_driver);
            _extensionMethods = new ExtensionMethods(_driver);
            _locator = new ElementLocator();
            _webElement = new WebElementLocator(_driver);
            //_dashboardPageLocator = new DashboardPageLocator();
            //_dashboardWebElement = new DashboardWebElement(_driver);
            //_dashboardButtonClick = new DashboardButtonClick(_driver);
            //_gettingValueMethods = new GettingValueMethods(_driver);
            //_waitMethods = new WaitMethods(_driver);

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


        public void Scroll(int x, int y)
        {
            var actions = new Actions(_driver);
            actions.ScrollByAmount(x, y);
            actions.Perform();
        }

        public void MoveToElement(IWebElement webElement)
        {
            var actions = new Actions(_driver);
            actions.MoveToElement(webElement);
            actions.Perform();
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

                    Scroll(0, 600);

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
                            MoveToElement(nextButton);

                            Scroll(0, 100);

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
                        var popUpWindow = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".bloko-modal-overlay.bloko-modal-overlay_visible")));

                        if (popUpWindow != null)
                        {
                            _driver.SwitchTo().ActiveElement();

                            var anyWayResponseButton = popUpWindow.FindElement(By.XPath("//span[text()='Все равно откликнуться']/parent::button"));

                            anyWayResponseButton.Click();
                        }
                    }
                    catch (Exception)
                    {
                        Scroll(0, 600);
                        Thread.Sleep(1000);
                    }

                    Scroll(0, 600);
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
                            MoveToElement(nextButton);

                            Scroll(0, 100);

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
