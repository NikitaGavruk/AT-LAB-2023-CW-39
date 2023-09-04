using AndroidUI.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidUI.Pages
{
    public class ArticlePage
    {
        private By title = By.CssSelector(".android.widget.TextView"); //first element is title

        public string GetTitle() => DriverExtensions.GetText(title);      
    }
}
