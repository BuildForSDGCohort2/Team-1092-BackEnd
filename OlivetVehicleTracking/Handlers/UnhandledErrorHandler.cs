using Microsoft.AspNetCore.Mvc.Filters;

namespace OlivetVehicleTracking.Handlers
{
    public class UnhandledErrorHandler : ExceptionFilterAttribute
    {
        public async override void OnException(ExceptionContext context)
        {
            var ex = context.Exception;

            await ErrorLog.Log("UnhandledErrorHandler", "OnException", ex.Message + ex.StackTrace);

            context.ExceptionHandled = true; //optional 
        }
    }
}
