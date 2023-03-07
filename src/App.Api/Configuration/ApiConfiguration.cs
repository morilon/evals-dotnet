using System.IO.Compression;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;

namespace FPS.TechEval.App.Api.Configuration;

internal static class ApiConfiguration
{
    internal static IServiceCollection AddDefaultVersioning(this IServiceCollection services)
    {
        return services
            .AddApiVersioning(x =>
            {
                x.ReportApiVersions = true;
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.DefaultApiVersion = new ApiVersion(1, 0);
            })
            .AddVersionedApiExplorer(x =>
            {
                x.GroupNameFormat = "'v'V";
                x.SubstituteApiVersionInUrl = true;
            });
    }

    internal static IServiceCollection AddDefaultResponseCompression(this IServiceCollection services)
    {
        return services
            .Configure<GzipCompressionProviderOptions>(x => x.Level = CompressionLevel.Optimal)
            .AddResponseCompression(x =>
            {
                x.EnableForHttps = true;
                x.Providers.Add<GzipCompressionProvider>();
            });
    }
}
