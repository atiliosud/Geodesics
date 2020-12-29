using System;
using Microsoft.AspNetCore.Mvc.Filters;


namespace Geodesics.Infra.CrossCutting.Filter
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly NotificationContext _notificationContext;

        public NotificationFilter(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationContext.Invalid)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                var notifications = JsonConvert.SerializeObject(_notificationContext.Notifications.Select(s => s.Message));
                await context.HttpContext.Response.WriteAsync(notifications);

                return;
            }

            await next();
        }
    }
}