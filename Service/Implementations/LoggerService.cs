using System;
using NLog;
using Service.Contracts;

namespace Service.Implementations
{
    public class LoggerService : ILoggerService
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();
        
        public void LogInfo(string message)
        {
            _logger.Info(message);
        }

        public void LogWarn(string message)
        {
            _logger.Warn(message);
        }

        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }
        
        public void LogError(string message, Exception ex)
        {
            _logger.Error(message, ex);
        }
    }
}