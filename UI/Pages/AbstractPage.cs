using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.WebDriver;

namespace UI.Pages
{
    public abstract class AbstractPage
    {
        public T NavigateToUrl<T>(string url) where T : AbstractPage
        {
            Browser.GetDriver().Navigate().GoToUrl(url);
            return (T)Activator.CreateInstance(typeof(T));

        }
    }
}