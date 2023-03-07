using FPS.TechEval.App.Api.Configuration;
using FPS.TechEval.App.Api.Configuration.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FPS.TechEval.App.Api.Configuration;

internal static class SwaggerConfiguration
{
    internal static IServiceCollection AddDefaultSwagger(this IServiceCollection services)
    {
        return services
            .AddSingleton<IConfigureOptions<SwaggerGenOptions>, SwaggerVersionConfiguration>()
            .AddSwaggerGen(x => x.DescribeAllParametersInCamelCase());
    }

    internal static IApplicationBuilder UseDefaultSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider apiProvider)
    {
        app
            .UseSwagger()
            .UseSwaggerUI(options =>
            {
                options.DocumentTitle = "Technical Interview Swagger UI";

                foreach (var description in apiProvider.ApiVersionDescriptions)
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());

                options.OAuthUsePkce();
            });

        return app;
    }
}