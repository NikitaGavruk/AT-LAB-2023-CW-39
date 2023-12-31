﻿using System;
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