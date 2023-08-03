using System;
using System.IO;
using Core.Interfaces;
using LogLevel = Core.enums.LogLevel;

namespace Core.Utils
{
    public class CustomLogger : ICustomLogger
    {
        private string _logFilePath;        
        private string _timeStamp;

        public CustomLogger()
        {            
            _timeStamp = DateTime.Now.ToString("yyyyMMdd_HH_mm_ss");

            var binDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var logDirectory = Path.Combine(binDirectory, "Logs");
            
            _logFilePath = Path.Combine(logDirectory, $"log_{_timeStamp}.txt");

            Directory.CreateDirectory(Path.GetDirectoryName(_logFilePath));            
        }
        
        public void LogError(Exception exception, string message)
        {            
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
