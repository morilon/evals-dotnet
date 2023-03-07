using System;
using FPS.TechEval.App.Api.Configuration;
using FPS.TechEval.App.Api.Singletons;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder
        .Services
        .AddDefaultVersioning()
        .AddDefaultResponseCompression()
        .AddDefaultSwagger()
        .AddControllers();

    var app = builder.Build();

    app
        .UseResponseCompression()
        .UseHttpsRedirection()
        .UseDefaultSwagger(app.Services.GetRequiredService<IApiVersionDescriptionProvider>())
        .UseRouting()
        .UseEndpoints(x => x.MapControllers());

    ConsoleLogger.Info("App is starting up.");

    app.Run();
}
catch (Exception e)
{
    ConsoleLogger.Error("App terminated unexpectedly.", e);
}
finally
{
    ConsoleLogger.Info("App is shutting down.");
}
