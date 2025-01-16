using System.Reflection;

namespace TemplateGenerator;

internal static class Generator
{
    public static void Generate(string[] args)
    {
        var title = args.ElementAtOrDefault(0) ?? ConsoleHelper.Read("Title");
        var signature = args.ElementAtOrDefault(1) ?? ConsoleHelper.Read("Signature");
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
        generator.Generate(args.ElementAtOrDefault(2));
    }
}
