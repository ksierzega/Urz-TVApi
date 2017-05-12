using System.Web.Http.ExceptionHandling;

namespace TvApiLabUr.Infrastructure
{
    public class NLogExceptionLogger : ExceptionLogger
    {
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public override void Log(ExceptionLoggerContext context)
        {
            _logger.Error(context.Exception);
        }
    }
}