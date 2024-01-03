using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Events;

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



        [Test]
        public void Test1()
        {
            
            var button = _webElement.RespondButton;

            while (button != null)
            {
                var newButton = _webElement.RespondButton;

                Scroll(0, 700);


                try 
                {                   
                    newButton.Click();
                }
                catch(Exception ex)
                {
                    Scroll(0, 700);
                }
                
                var newButton1 = _webElement.RespondButton;

                Thread.Sleep(3000);

            }

            var buttonNext = _webElement.NextButton;
            buttonNext.Click();

        }





        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
