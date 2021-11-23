using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasparCgPlayer.UI.Startup
{
    public class LogHelper
    {
        private Logger _logger;

        public Logger Logger { get => _logger; }

        public LogHelper()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void Error(Exception exception, LogLevel logLevel, string description = null, string sqlQuery = null)
        {
            var message = new ExceptionMessage()
            {
                Message = CreateErrorMessage(exception, description, sqlQuery),
                Date = DateTime.Now,
                LogLevel = logLevel
            };

            _logger.Error(message);
        }

        private string CreateErrorMessage(Exception exception, string description, string sqlQuery)
        {
            var stacktrace = string.Join(", ", GetInternalExceptionMessages(exception));

            var templateList = new List<string>();
            
            if (!string.IsNullOrEmpty(description))
            {
                templateList.Add($"Description: {description}");
            }

            if (!string.IsNullOrEmpty(sqlQuery))
            {
                templateList.Add($"SQL: {sqlQuery}");
            }

            if (!string.IsNullOrWhiteSpace(stacktrace))
            {
                templateList.Add($"Stacktrace: {stacktrace}");
            }

            return string.Join(Environment.NewLine, templateList);
        }

        private IEnumerable<string> GetInternalExceptionMessages(Exception exception)
        {
            do
            {
                yield return exception.Message;

                exception = exception.InnerException;

            } while (exception.InnerException != null);
        }
    }

    [Serializable]
    public class ExceptionMessage
    {
        public DateTime Date { get; set; }

        public LogLevel LogLevel { get; set; }

        public string Message { get; set; }
    }
}
