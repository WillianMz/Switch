using Microsoft.Extensions.Logging;
using System;

namespace Switch.Infra.CrossCutting.Logging
{
    public class Logger : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new InternalLogger();
        }

        public void Dispose()
        {
            
        }

        private class InternalLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                //registra tudo o que ocorre no sistema dentro deste arquivo
                System.IO.File.AppendAllText(@"c:\temp\log.txt", formatter(state, exception));
                //exibe a mesma coisa que sera gravado no arquivo na tela
                Console.WriteLine(formatter(state, exception));
            }
        }

    }
}
