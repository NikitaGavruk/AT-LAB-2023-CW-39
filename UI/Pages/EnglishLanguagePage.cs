﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Utils;

namespace UI.Pages
{
    public class EnglishLanguagePage : AbstractPage
    {
        private static readonly By uzbekWikipediaPage = By.LinkText("Uzbek Wikipedia");
        private static readonly By title = By.XPath("//span[@class='mw-page-title-main']");

        public string GetTitle()
        {
            return WebDriverExtension.GetTextFromElement(title);
        }

        public bool UzbekLanguageButtonIsVisible()
        {
            return WebDriverExtension.IsElementVisible(uzbekWikipediaPage);
        }

        public EnglishLanguagePage ClickUzbekLanguageButton()
        {
            WebDriverExtension.ClickOnElement(uzbekWikipediaPage);
            return new EnglishLanguagePage();
        }
    }
}