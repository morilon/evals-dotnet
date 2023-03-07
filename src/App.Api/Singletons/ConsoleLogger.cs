using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FPS.TechEval.App.Api.Singletons;

public static class ConsoleLogger
{
    public static void Error(string message, Exception ex)
    {
        Console.WriteLine(
            JsonSerializer.Serialize(new { Message = message, Exception = ex },
            new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.Never,
                MaxDepth = 1,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            }));
    }

    public static void Info(string message)
    {
        Console.WriteLine(
            JsonSerializer.Serialize(new { Message = message },
            new JsonSerializerOptions { WriteIndented = true }));
    }
}