using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.Swagger;

namespace Geodesics.Api.Infrastructure.Swagger
{
    /// <summary>
    /// A Swagger document filter, which transforms all paths to lower case.
    /// </summary>
    public class LowercaseDocumentFilter : Swashbuckle.AspNetCore.SwaggerGen.IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context) =>
            swaggerDoc.paths = swaggerDoc.paths
                .ToDictionary(entry =>
                    LowercaseEverythingButParameters(entry.Key), entry => entry.Value);

        private static string LowercaseEverythingButParameters(string key) =>
            string.Join('/', key.Split('/')
                .Select(x => x.Contains("{") ? x : x.ToLowerInvariant()));

        void Swashbuckle.AspNetCore.SwaggerGen.IDocumentFilter.Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
