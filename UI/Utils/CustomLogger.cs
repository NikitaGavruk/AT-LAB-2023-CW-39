using OpenQA.Selenium;
using System;
using System.IO;
using UI.Interfaces;
using LogLevel = UI.enums.LogLevel;

namespace UI.Utils
{
    public class CustomLogger : ICustomLogger
    {
        private string _logFilePath;
        private string _screenshotDirectory;
        private IWebDriver _webDriver;
        private string _timeStamp;

        public CustomLogger(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _timeStamp = DateTime.Now.ToString("yyyyMMdd_HH_mm_ss");

            var binDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var logDirectory = Path.Combine(binDirectory, "Logs");
            var screenshotDirectory = Path.Combine(binDirectory, "Screenshots");

            _logFilePath = Path.Combine(logDirectory, $"log_{_timeStamp}.txt");
            _screenshotDirectory = screenshotDirectory;

            Directory.CreateDirectory(Path.GetDirectoryName(_logFilePath));
            Directory.CreateDirectory(screenshotDirectory);
        }
        
        public void LogError(Exception exception, string message)
        {
            var screenshotFilePath = Path.Combine(_screenshotDirectory, $"screenshot_{_timeStamp}.png");

            try
            {
                var screenshotDriver = _webDriver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
                message = $"{message}. Screenshot saved to {screenshotFilePath}";
            }
            catch (Exception ex)
            {
                message = $"{message}. Failed to save screenshot due to: {ex.Message}";
            }
            using (StreamWriter streamWriter = new StreamWriter(_logFilePath, true))
            {
                streamWriter.WriteLine($"{DateTime.Now:G}: ERROR: {message} - {exception}");
            }
        }

        public void LogInfo(LogLevel logLevel, string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(_logFilePath, true))
            {
                streamWriter.WriteLine($"{DateTime.Now:G}: {logLevel}: {message}");
            }
        }
    }
}
