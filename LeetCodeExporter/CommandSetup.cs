using System.CommandLine;

namespace LeetCodeExporter;

public static class CommandSetup
{
    public static RootCommand CreateCommand(Action<string, int?> handler)
    {
        var problemOption = new Option<string>("--problem", "-p")
        {
            Description = "LeetCode problem number (e.g. 3508)",
            Required = true
        };

        var solutionOption = new Option<int?>("--solution", "-s")
        {
            Description = "Solution number (default: highest)"
        };

        var rootCommand = new RootCommand("Export a LeetCode solution to clipboard-ready format")
        {
            problemOption,
            solutionOption
        };

        rootCommand.SetAction(parseResult => handler(parseResult.GetValue(problemOption)!, parseResult.GetValue(solutionOption)));
        return rootCommand;
    }
}
