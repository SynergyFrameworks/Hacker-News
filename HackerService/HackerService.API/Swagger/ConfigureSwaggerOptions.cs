using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace HackerService.API.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider _apiVerProvider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiVerProvider) => _apiVerProvider = apiVerProvider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _apiVerProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, GetSwaggerDocInfo(description));
            }
        }

        static OpenApiInfo GetSwaggerDocInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = $"Hacker News WebAPI {description.ApiVersion}",
                Version = description.GroupName,
                Description = "Web API by Aaron Prince",
                Contact = new OpenApiContact()
                {
                    Name = "Hacker News Web API service",
                    Email = string.Empty,
                    Url = new Uri("https://github.com/HackerNews/API"),
                },
                License = new OpenApiLicense()
                {
                    Name = "MIT Hacker News",
                    Url = new Uri("https://github.com/HackerNews/API")
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += $" {description.ApiVersion} API version is deprecated.";
            }

            return info;
        }
    }
}
