using System.CommandLine;
using System.Diagnostics;
using LeetCodeExporter;

var baseDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "LeetCode"));
var fileSystem = new RealFileSystem();
var finder = new SolutionFinder(fileSystem, baseDir);

var command = CommandSetup.CreateCommand((problemNumber, solutionNumber) =>
{
    var filePath = finder.FindSolutionFile(problemNumber, solutionNumber);

    if (filePath == null)
    {
        Console.Error.WriteLine($"No solution found for problem {problemNumber}");
        Environment.ExitCode = 1;
        return;
    }

    Console.Error.WriteLine($"Exporting: {filePath}");

    var source = fileSystem.ReadAllText(filePath);
    var result = SolutionTransformer.Transform(source);

    Console.Write(result);
    CopyToClipboard(result);
});

return command.Invoke(args);

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
