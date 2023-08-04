using System;
using LogLevel = Core.enums.LogLevel;

namespace Core.Interfaces
{
    public interface ICustomLogger
    {
        void LogInfo(LogLevel logLevel, string message);
        void LogError(Exception exception, string message);
    }
}