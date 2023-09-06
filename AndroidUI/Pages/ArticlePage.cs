using AndroidUI.Utils;
using OpenQA.Selenium;

namespace AndroidUI.Pages
{
    public class ArticlePage
    {
        private By title = By.CssSelector(".android.widget.TextView"); //first element is title
        private By optionMenu = By.Id("org.wikipedia:id/page_toolbar_button_show_overflow_menu");
        private By watchButton = By.Id("org.wikipedia:id/page_watch");
        private By unwatchButton = By.XPath("//*[contains(@text,'Unwatch')]");

        public string GetTitle() => DriverExtensions.GetText(title);

        public ArticlePage ClickWatch()
        {
            DriverExtensions.ClickToElement(optionMenu);
            DriverExtensions.ClickToElement(watchButton);
            return new ArticlePage();
        }

        public bool IsArticleWatched()
        {
            DriverExtensions.ClickToElement(optionMenu);

            var addedIcon = DriverExtensions.GetElement(unwatchButton);

            return addedIcon != null;
        }
    }
}
