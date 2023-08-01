using OpenQA.Selenium;
using System;
using UI.Utils;

namespace UI.Pages
{
    public class LogoutPage : AbstractPage
    {
        private static readonly By toMainPageLink = By.CssSelector("[title=\"Main Page\"]");

        public MainPage ToMainPage()
        {
            WebDriverExtension.ClickOnElement(toMainPageLink);
            return new MainPage();
        }
    }
}
