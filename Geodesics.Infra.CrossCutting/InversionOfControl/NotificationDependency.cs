using Geodesics.Infra.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Geodesics.Infra.CrossCutting.InversionOfControl
{
    public static class NotificationDependency
    {
        public static void AddNotificationDependency(this IServiceCollection services)
        {
            services.AddScoped<NotificationContext>();
        }
    }
}
