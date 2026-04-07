using System.CommandLine;

namespace LeetCodeExporter;

public static class CommandSetup
{
    public static RootCommand CreateCommand(Action<string, int?> handler)
    {
        var problemOption = new Option<string>("--problem", "LeetCode problem number (e.g. 3508)") { IsRequired = true };
        problemOption.AddAlias("-p");

        var solutionOption = new Option<int?>("--solution", "Solution number (default: highest)");
        solutionOption.AddAlias("-s");

        var rootCommand = new RootCommand("Export a LeetCode solution to clipboard-ready format")
        {
            problemOption,
            solutionOption
        };

        rootCommand.SetHandler(handler, problemOption, solutionOption);
        return rootCommand;
    }
}
