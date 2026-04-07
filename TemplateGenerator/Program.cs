using System.CommandLine;

namespace TemplateGenerator;

internal static class Program
{
    public static int Main(string[] args)
    {
        var rootCommand = new RootCommand("LeetCode problem template generator");
        Generator.ConfigureRootCommand(rootCommand);
        return rootCommand.Parse(args).Invoke();
    }
}
