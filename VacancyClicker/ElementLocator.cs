using OpenQA.Selenium;

namespace VacancyClicker
{
    public class ElementLocator
    {

        public By RespondButtonLocator = By.PartialLinkText("Откликнуться");

        public By AnywayResponsePopUp = By.CssSelector("body > div.undefined.bloko-modal-overlay.bloko-modal-overlay_visible > div");

        public By AnyWayResponseButtonLocator = By.CssSelector("body > div.magritte-overlay___hMlKJ_1-3-10.magritte-animation-timeout___cwIwT_1-3-10 > div > div.magritte-buttons___lyxBC_1-3-10.magritte-buttons_vertical___8lPCo_1-3-10 > button.magritte-button___Pubhr_5-1-9.magritte-button_mode-primary___wU8PN_5-1-9.magritte-button_size-medium___WvUsb_5-1-9.magritte-button_style-accent___TE21J_5-1-9 > div > span > span");







    }
}
