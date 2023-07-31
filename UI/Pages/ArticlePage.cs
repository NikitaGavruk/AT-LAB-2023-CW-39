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
        public static readonly By editButton = By.CssSelector("#ca-edit>a>span");
        public static readonly By title = By.CssSelector("#firstHeading>span");
        public static readonly By viewHistoryButton = By.CssSelector("#ca-history>a>span");

        public string GetTitle(int timeSeconds)
        {
            return WebDriverExtension.GetTextFromElement(title, timeSeconds);
        }

        public void ClickToViewHistory(int timeSeconds)
        {
            WebDriverExtension.ClickOnElement(viewHistoryButton, timeSeconds);
        }

        public void ClickToEdit(int timeSeconds)
        {
            WebDriverExtension.ClickOnElement(editButton, timeSeconds);
        }
    }
}
