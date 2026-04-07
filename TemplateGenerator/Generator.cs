using System.CommandLine;
using System.Reflection;

namespace TemplateGenerator;

internal static class Generator
{
    public static IGenerator[] DiscoverGenerators()
    {
        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IGenerator)) && !t.IsAbstract)
            .Select(t => Activator.CreateInstance(t) as IGenerator
                ?? throw new InvalidOperationException($"Failed to create instance of {t.Name}"))
            .ToArray();
    }

    public static void ConfigureRootCommand(RootCommand rootCommand)
    {
        var generators = DiscoverGenerators();

        foreach (var generator in generators)
        {
            var command = new Command(generator.CommandName, generator.CommandDescription);
            generator.ConfigureCommand(command);
            command.SetAction(result =>
            {
                generator.SetOptions(result);
                generator.Generate();
            });
            rootCommand.Add(command);
        }
    }
}
