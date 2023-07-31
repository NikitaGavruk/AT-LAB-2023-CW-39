using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Utils;

namespace UI.Pages
{
    internal class EditHistoryPage : AbstractPage
    {
        public static readonly By title = By.CssSelector("#firstHeading");

        public bool IsPageVisible(int timeSeconds)
        {
            return WebDriverExtension.IsElementVisible(title, timeSeconds);
        }
    }
}
