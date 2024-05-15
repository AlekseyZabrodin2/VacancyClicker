using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyClicker
{
    public class ElementLocator
    {

        public By RespondButtonLocator = By.PartialLinkText("Откликнуться");

        public By AnywayResponsePopUp = By.CssSelector(".bloko-modal-overlay.bloko-modal-overlay_visible");

        public By AnyWayResponseButtonLocator = By.XPath("//span[text()='Все равно откликнуться']/parent::button");







    }
}
