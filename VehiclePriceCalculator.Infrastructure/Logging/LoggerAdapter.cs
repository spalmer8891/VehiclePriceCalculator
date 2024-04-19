using VehiclePriceCalculator.Domain.Interfaces;
using Microsoft.Extensions.Logging;


namespace VehiclePriceCalculator.Infrastructure.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            //loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            loggerFactory.AddFile("Exceptions/Logs/mylog-{Date}.txt");
            _logger = loggerFactory.CreateLogger<T>();
            
           
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }
    }
}
