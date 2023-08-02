using System;
using LogLevel = UI.enums.LogLevel;

namespace UI.Interfaces
{
    public interface ICustomLogger
    {
        void LogInfo(LogLevel logLevel, string message);
        void LogError(Exception exception, string message);
    }
}