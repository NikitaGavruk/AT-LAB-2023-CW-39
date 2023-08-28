using AndroidUI.Driver;
using Core.Interfaces;
using Core.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace AndroidUI.Utils
{
    public class Screenshoter
    {
        private static IWebDriver driver => DriverFactory.GetDriver();
        private static ICustomLogger logger;
        private static string screenshotDirectory;

        static Screenshoter()
        {
            screenshotDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
            logger = new CustomLogger();
        }

        public static void Capture()
        {
            try
            {
                string timeStamp = DateTime.Now.ToString("yyyyMMdd_HH_mm_ss");
                var screenshotFilePath = Path.Combine(screenshotDirectory, $"screenshot_{timeStamp}.png");
                Directory.CreateDirectory($"{AppDomain.CurrentDomain.BaseDirectory}/Screenshots");

                driver.TakeScreenshot().
                    SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);

                logger.LogInfo(Core.enums.LogLevel.Info, $"Screenshot saved to {screenshotFilePath}");
            }
            catch(Exception ex)
            {
                logger.LogInfo(Core.enums.LogLevel.Info, $"Failed to save screenshot due to: {ex.Message}");
            }            
        }
    }
}
