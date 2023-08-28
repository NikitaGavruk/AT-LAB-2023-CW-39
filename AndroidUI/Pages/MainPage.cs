using AndroidUI.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidUI.Pages
{
    public class MainPage
    {
        private By inactiveSearchField = By.CssSelector("android.widget.TextView");
        private By activeSearchField = By.CssSelector("android.widget.EditText");

        public MainPage ClickToSearchField()
        {
            DriverExtensions.ClickToElement(inactiveSearchField);
            return new MainPage();
        }

        public MainPage pastSearchRequest(string searchRequest)
        {
            DriverExtensions.SendKeys(activeSearchField, searchRequest); 
            return new MainPage();
        }
    }
}
