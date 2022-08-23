namespace TShirtSizeConverter.Lib;

public static class App
{
    public static void Run(IEnumerable<string> args, Action<string> feedback)
    {
        var conversionService = new ConversionService();
        var value = args?.FirstOrDefault() ?? string.Empty;
        if (!string.IsNullOrEmpty(value))
        {
            value = conversionService.Convert(value);
        }
        feedback(value);
    }
}