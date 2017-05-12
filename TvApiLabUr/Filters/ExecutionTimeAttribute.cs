using System.Diagnostics;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace TvApiLabUr.Filters
{
    public class ExecutionTimeAttribute : ActionFilterAttribute
    {
        private const string StopwatchKey = "StopwatchKey";

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            actionContext.Request.Properties.Add(StopwatchKey, Stopwatch.StartNew());
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Request.Properties.ContainsKey(StopwatchKey))
            {
                var stopwatch = (Stopwatch)actionExecutedContext.Request.Properties[StopwatchKey];
                stopwatch.Stop();

                actionExecutedContext.Response.Headers.Add("Elapsed-Time", stopwatch.ElapsedMilliseconds.ToString());
            }
        }
    }
}