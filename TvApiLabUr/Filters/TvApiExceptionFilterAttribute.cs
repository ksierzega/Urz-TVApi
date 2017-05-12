using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using TvApiLabUr.Common;

namespace TvApiLabUr.Filters
{
    public class TvApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is TvApiException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionExecutedContext.Exception.Message);
            }
        }
    }
}