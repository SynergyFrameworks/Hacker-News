using System;
using System.Linq;
using HackerService.BLL;
using HackerService.BLL.Contracts;
using HackerService.BLL.Models;
using HackerService.DAL;
using HackerService.DAL.Contract;
using HackerService.DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Polly;

namespace HackerService.Configuration
{
    public static class WebServiceExtensions
    {
        public static IServiceCollection AddWebServices(
            this IServiceCollection services,
            IConfigurationSection bllOptionsSection,
            IConfigurationSection dalOptionSection)
        {
            if (bllOptionsSection == null)
            {
                throw new ArgumentNullException(nameof(bllOptionsSection));
            }

            if (dalOptionSection == null)
            {
                throw new ArgumentNullException(nameof(dalOptionSection));
            }

            var bllSettings = bllOptionsSection.Get<HackerNewsBllOptions>();

            services.Configure<HackerNewsBllOptions>(opt =>
            {
                opt.JwtSecretKey = bllOptionsSection.GetValue<string>("JwtSecretKey");
                opt.WebApiUrl = bllOptionsSection.GetValue<string>("WebApiUrl");
            });
            services.Configure<HackerNewsRepositoryOption>(opt =>
            {
                opt.NewsDbConnectionString = dalOptionSection.GetValue<string>("NewsDbConnectionString");
            });

            services.TryAddSingleton<IHackerNewsRepository, HackerNewsRepository>();

            services.TryAddScoped<IHackerNewsService, HackerNewsService>();
            services.TryAddScoped<IJwtTokenService, JwtTokenService>();

            services.AddHttpClient();
            services.AddHttpClient<TodosMockProxyService>(c =>
            {
                c.BaseAddress = new Uri(bllSettings.WebApiUrl);
            }).AddTransientHttpErrorPolicy(p =>
                p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600))
            );

            services.AddHealthChecks()
                .AddCheck<HackerNewsRepository>("HackerNewsRepository")
                .AddCheck<TodosMockProxyService>("TodosMockProxyService");

            return services;
        }

        public static IApplicationBuilder UseWebServices(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/api/health", new HealthCheckOptions()
            {
                ResponseWriter = (httpContext, result) =>
                {
                    httpContext.Response.ContentType = "application/json";

                    var json = new JObject(
                        new JProperty("status", result.Status.ToString()),
                        new JProperty("results", new JObject(result.Entries.Select(pair =>
                            new JProperty(pair.Key, new JObject(
                                new JProperty("status", pair.Value.Status.ToString())))))));
                    return httpContext.Response.WriteAsync(
                        json.ToString(Formatting.Indented));
                }
            });

            return app;
        }
    }
}
