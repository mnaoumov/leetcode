using System.CommandLine;
using System.Diagnostics;
using LeetCodeExporter;

var problemNumberArgument = new Argument<string>("problem-number", "LeetCode problem number (e.g. 3508)");
var solutionNumberOption = new Option<int?>("--solution", "Solution number (default: highest)");
solutionNumberOption.AddAlias("-s");

var rootCommand = new RootCommand("Export a LeetCode solution to clipboard-ready format")
{
    problemNumberArgument,
    solutionNumberOption
};

rootCommand.SetHandler(Run, problemNumberArgument, solutionNumberOption);
return rootCommand.Invoke(args);

static void Run(string problemNumber, int? solutionNumber)
{
    var filePath = SolutionFinder.FindSolutionFile(problemNumber, solutionNumber);

    if (filePath == null)
    {
        Console.Error.WriteLine($"No solution found for problem {problemNumber}");
        Environment.ExitCode = 1;
        return;
    }

    Console.Error.WriteLine($"Exporting: {filePath}");

    var source = File.ReadAllText(filePath);
    var result = SolutionTransformer.Transform(source);

    Console.Write(result);
    CopyToClipboard(result);
}

static void CopyToClipboard(string text)
{
    if (!OperatingSystem.IsWindows())
    {
        return;
    }

    var process = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "clip",
            RedirectStandardInput = true,
            UseShellExecute = false
        }
    };
    process.Start();
    process.StandardInput.Write(text);
    process.StandardInput.Close();
    process.WaitForExit();
    Console.Error.WriteLine("Copied to clipboard.");
}
