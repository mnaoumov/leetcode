using System.CommandLine;

namespace LeetCodeExporter;

public static class CommandSetup
{
    public static RootCommand CreateCommand(Action<string, int?> handler)
    {
        var problemNumberArgument = new Argument<string>("problem-number", "LeetCode problem number (e.g. 3508)");
        var solutionNumberOption = new Option<int?>("--solution", "Solution number (default: highest)");
        solutionNumberOption.AddAlias("-s");

        var rootCommand = new RootCommand("Export a LeetCode solution to clipboard-ready format")
        {
            problemNumberArgument,
            solutionNumberOption
        };

        rootCommand.SetHandler(handler, problemNumberArgument, solutionNumberOption);
        return rootCommand;
    }
}
