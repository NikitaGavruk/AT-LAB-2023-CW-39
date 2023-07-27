using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Utils;

namespace UI.Pages
{
    internal class ArticlePage : AbstractPage
    {
        private static By editButton = By.CssSelector("#ca-edit>a>span");
        private static By title = By.CssSelector("#firstHeading>span");
        private static By viewHistoryButton = By.CssSelector("#ca-history>a>span");

        public string GetTitle()
        {
            return WebDriverExtension.GetTextFromElement(title, 5);
        }
    }
}
