using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace FreeSmokyMarket
{
    public class FileLogger : ILogger
    {
        private string _filePath;
        private object _lock = new object();

        public FileLogger(string path)
        {
            _filePath = path;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            if (logLevel == LogLevel.Information)
            {
                return true;
            }
            return false;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (IsEnabled(logLevel))
            {
                if (formatter != null)
                {
                    lock (_lock)
                    {
                        File.AppendAllText(_filePath, "[" + DateTime.Now.ToString() + "]" + formatter(state, exception) + Environment.NewLine);
                    }
                }
            }
        }
    }
}
