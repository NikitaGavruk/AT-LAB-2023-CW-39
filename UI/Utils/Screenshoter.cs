using Core.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;
using UI.WebDriver;
using Core.Utils;

namespace UI.Utils
{
    public class Screenshoter
    {
        private static string screenshotDirectory;
        private static ICustomLogger logger;

        static Screenshoter()
        {
            var screenshotDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
            Directory.CreateDirectory(screenshotDirectory);
            logger = new CustomLogger();
        }

        public static void Capture()
        {
            string _timeStamp = DateTime.Now.ToString("yyyyMMdd_HH_mm_ss");
            var webDriver = Browser.GetDriver();
            var screenshotFilePath = Path.Combine(screenshotDirectory, $"screenshot_{_timeStamp}.png");

            try
            {
                var screenshotDriver = webDriver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
                logger.LogInfo(Core.enums.LogLevel.Info, $"Screenshot saved to {screenshotFilePath}");                
            }
            catch (Exception ex)
            {
                logger.LogInfo(Core.enums.LogLevel.Info, $"Failed to save screenshot due to: {ex.Message}");
            }
        }
    }
}
