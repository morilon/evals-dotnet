﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FPS.TechEval.App.Api.Configuration.Swagger;

internal sealed class SwaggerVersionConfiguration : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _versionProvider;

    public SwaggerVersionConfiguration(
        IApiVersionDescriptionProvider versionProvider)
    {
        _versionProvider = versionProvider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var version in _versionProvider.ApiVersionDescriptions)
            options.SwaggerDoc(version.GroupName, new()
            {
                Title = "Technical Interview Swagger",
                Version = version.GroupName
            });
    }
}