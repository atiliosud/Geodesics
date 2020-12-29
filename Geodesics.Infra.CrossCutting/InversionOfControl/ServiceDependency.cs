using Geodesics.Domain.Interfaces;
using Geodesics.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geodesics.Infra.CrossCutting.InversionOfControl
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IDistanceService, DistanceService>();
        }
    }
}
