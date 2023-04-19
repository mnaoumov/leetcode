using System.Reflection;

namespace TemplateGenerator;

internal static class Generator
{
    public static void Generate()
    {
        var title = ConsoleHelper.Read("Title");
        var signature = ConsoleHelper.Read("Signature");
        var generator = Assembly.GetExecutingAssembly()
                            .GetTypes().Where(t => t.IsAssignableTo(typeof(IGenerator)) && !t.IsAbstract)
                            .Select(t =>
                            {
                                var generator = (IGenerator) Activator.CreateInstance(t)!;
                                generator.Init(title, signature);
                                return generator;
                            })
                            .FirstOrDefault(g => g.CanGenerate())
                        ?? throw new Exception($"Unsupported signature: {signature}");
        generator.Generate();
    }
}