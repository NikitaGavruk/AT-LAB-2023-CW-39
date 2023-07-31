using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Utils;

namespace UI.Pages
{
    internal class EditPage : AbstractPage
    {
        public static readonly By notLoggedWarning = By.CssSelector(".mw-halign-left");

        public bool IsNotLoggedWarningDisplayed()
        {            
            return WebDriverExtension.IsElementVisible(notLoggedWarning, 5);
        }
    }
}
