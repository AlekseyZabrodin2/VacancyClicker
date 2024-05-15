using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using NLog;
using SeleniumExtras.WaitHelpers;

namespace VacancyClicker
{
    class ExtensionMethods
    {

        private EventFiringWebDriver _driver;
        internal static WebDriverWait _wait;
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();


        public ExtensionMethods(EventFiringWebDriver driver)
        {
            this._driver = driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }


        public void ClearInputField(By FieldForInputChose)
        {
            var fieldForInput = _driver.FindElement(FieldForInputChose);
            fieldForInput.Click();
            fieldForInput.SendKeys(Keys.Control + "a");
            fieldForInput.SendKeys(Keys.Backspace);
        }



        public bool IsElementPresent(By locator)
        {
            try
            {
                _driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Something wrong");
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public bool CheckElementExists(By by, int second)
        {
            bool result = false;
            try
            {
                _logger.Debug("Entering void CheckElementExists");

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(second);
                _wait.Until(ExpectedConditions.ElementExists(by));

                result = true;
            }
            catch (Exception ex)
            {
                _logger.Warn("Search failed");
                Console.WriteLine(ex.Message);
                result = false;
            }
            _logger.Info($"CheckElement result - [{result}]");
            return result;
        }

        public bool WaitUntilElementIsDisplayed(By element, int second)
        {
            _logger.Debug("Entering void WaitUntilElementIsDisplayed");

            for (int i = 0; i < second; i++)
            {
                _logger.Info($"Wait {i} second");

                if (CheckElementExists(element, second))
                {
                    _driver.FindElement(element);

                    _logger.Info($"[{element}] found");
                    return true;
                }
                _logger.Info($"Repeat {i}");

            }
            _logger.Error("Element did not finde");
            return false;
        }



        public bool SearchElement(By by, int second)
        {
            bool result = false;
            try
            {
                _logger.Debug("Enter to SearchElement");

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(second);
                _driver.FindElement(by);

                result = true;
            }
            catch (Exception ex)
            {
                _logger.Warn("Didn't find anything");
                result = false;
            }
            _logger.Info($"SearchElementExists result - [{result}]");
            return result;
        }

        public bool ClickAndWaitUntilElementIsDisplayed(By element, By button, int second, int count)
        {
            _logger.Debug("Enter to WaitUntilElementIsDisplayed");

            for (int i = 0; i < count; i++)
            {
                if (!SearchElement(element, second))
                {
                    _driver.FindElement(button).Click();
                    _logger.Info($"Repeat {i}");
                }
                else
                {
                    _logger.Info($"[{element}] found");
                    return true;
                }
            }
            _logger.Error("Element did not finde");
            return false;
        }



        public bool SearchWindow(By by, int second)
        {
            bool result = false;
            try
            {
                _logger.Debug("Enter to SearchElement");

                var newWindowOpenedHandle = _driver.WindowHandles[1];
                _driver.SwitchTo().Window(newWindowOpenedHandle);

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(second);
                _driver.FindElement(by);

                result = true;
            }
            catch (Exception ex)
            {
                _logger.Warn("Didn't find anything");
                result = false;
            }
            _logger.Info($"SearchElementExists result - [{result}]");
            return result;
        }

        public bool ClickAndWaitWindow(By element, By button, int second, int count)
        {
            _logger.Debug("Enter to WaitUntilElementIsDisplayed");

            for (int i = 0; i < count; i++)
            {
                if (!SearchWindow(element, second))
                {
                    _driver.FindElement(button).Click();
                    _logger.Info($"Repeat {i}");
                }
                else
                {
                    _logger.Info($"[{element}] found");
                    return true;
                }
            }
            _logger.Error("Element did not finde");
            return false;
        }

    }
}
