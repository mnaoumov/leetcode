using System.CommandLine;
using System.Diagnostics;

namespace TemplateGenerator;

/// <summary>
/// Moves finished problems from !WIP/NNNN Title to their bucket, NN/NNNN Title. Namespaces do not include the
/// bucket, so nothing else changes.
/// </summary>
internal static class FinishCommand
{
    public static Command Create()
    {
        var numbersArgument = new Argument<int[]>("numbers")
        {
            Description = "Problem numbers to finish; without any, lists the !WIP problems to pick from",
            Arity = ArgumentArity.ZeroOrMore
        };
        var command = new Command("finish", "Move finished problems from !WIP into their numbered bucket") { numbersArgument };
        command.SetAction(result => Finish(result.GetValue(numbersArgument) ?? []));
        return command;
    }

    private static int Finish(int[] numbers)
    {
        return new ProblemFinisher(GeneratorBase.ProblemsFolderPath, Move, ShowDiff, Console.In, Console.Out, Console.Error).Finish(numbers);
    }

    /// <summary>
    /// Prints what would change; <c>git diff --no-index</c> works on any two folders, tracked or not.
    /// </summary>
    private static void ShowDiff(string existing, string replacement)
    {
        var git = Process.Start(new ProcessStartInfo("git", ["--no-pager", "diff", "--no-index", "--", existing, replacement])
        {
            WorkingDirectory = GeneratorBase.FindRepoRoot()
        })!;
        git.WaitForExit();
    }

    /// <summary>
    /// <c>git mv</c> keeps the move staged as a rename; a folder git does not track yet is moved on disk.
    /// </summary>
    internal static void Move(string source, string target)
    {
        var git = Process.Start(new ProcessStartInfo("git", ["mv", source, target])
        {
            WorkingDirectory = GeneratorBase.FindRepoRoot(),
            RedirectStandardError = true
        })!;
        git.WaitForExit();

        if (git.ExitCode != 0)
        {
            Directory.Move(source, target);
        }
    }
}
