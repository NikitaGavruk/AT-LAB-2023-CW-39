using OpenQA.Selenium;
using UI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Pages
{
    public class MainPage : AbstractPage
    {
        public static readonly By searchField = By.CssSelector("[name='search']");
        public static readonly By loginButton = By.CssSelector("#pt-login-2>a>span");
        public static readonly By openSideMenuButton = By.CssSelector("#vector-main-menu-dropdown-checkbox");
        public static readonly By randomPageButton = By.CssSelector("#n-randompage>a>span");
        public static readonly By title = By.CssSelector("#Welcome_to_Wikipedia");

        public bool IsPageVisible()
        {
            return WebDriverExtension.IsElementVisible(title, 5);
        }
    }
}
