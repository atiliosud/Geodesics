using System;
using System.IO;
using System.Reflection;
using Geodesics.Api.Infrastructure.Swagger;
using Geodesics.Infra.CrossCutting.Filter;
using Geodesics.Infra.CrossCutting.InversionOfControl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;

namespace Geodesics.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.EnableEndpointRouting = false;
                config.Filters.Add<NotificationFilter>();
            });
            services.AddServiceDependency();
            services.AddSwaggerDependency();
            services.AddNotificationDependency();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            app.UseSwaggerDependency();
        }
    }
}
