using System;
namespace TheMaze.Utils.Logging
{
    public class ConsoleLogger : ILogger
    {

        private readonly string _name;
        private readonly LoggerConfig _config;



        public ConsoleLogger(string name, LoggerConfig config)
        {
            _name = name;
            _config = config;
        }



        public IDisposable BeginScope<TState>(TState state)
        {

            return null;
        }


        public bool IsEnabled(LogLevel logLevel)
        {

            return logLevel == _config.LogLevel;

        }



        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {

            if (!IsEnabled(logLevel))
            {

                return;
            }


            if (_config.EventId == 0 || _config.EventId == eventId.Id)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = _config.Color;
                Console.WriteLine($"{logLevel.ToString()} - {eventId.Id} - {_name} - {formatter(state, exception)}");
                Console.ForegroundColor = color;
            }
        }
    }
}
