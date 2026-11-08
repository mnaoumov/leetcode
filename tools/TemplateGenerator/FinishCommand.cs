using System.CommandLine;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace TemplateGenerator;

/// <summary>
/// Moves finished problems from !WIP/NNNN Title to their bucket, NN/NNNN Title. Namespaces do not include the
/// bucket, so nothing else changes.
/// </summary>
internal static partial class FinishCommand
{
    [GeneratedRegex(@"^(\d{4}) ")]
    private static partial Regex ProblemFolderRegex();

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
        var wipFolders = Directory.GetDirectories(GeneratorBase.LeetCodeFolderPath)
            .Select(Path.GetFileName)
            .OfType<string>()
            .Where(name => ProblemFolderRegex().IsMatch(name))
            .Order()
            .ToArray();

        if (numbers.Length == 0)
        {
            if (wipFolders.Length == 0)
            {
                Console.WriteLine("!WIP holds no numbered problems.");
                return 0;
            }

            foreach (var name in wipFolders)
            {
                Console.WriteLine(name);
            }

            numbers = ConsoleHelper.Read("problem numbers to finish, separated by spaces")
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        var exitCode = 0;

        foreach (var number in numbers)
        {
            var padded = number.ToString("D4");
            var name = wipFolders.SingleOrDefault(folder => ProblemFolderRegex().Match(folder).Groups[1].Value == padded);

            if (name == null)
            {
                Console.Error.WriteLine($"{padded}: no !WIP/{padded} folder");
                exitCode = 1;
                continue;
            }

            var source = Path.Combine(GeneratorBase.LeetCodeFolderPath, name);
            var target = Path.Combine(GeneratorBase.ProblemsFolderPath, padded[..2], name);

            if (Directory.Exists(target))
            {
                Console.Error.WriteLine($"{padded}: {padded[..2]}/{name} already exists");
                exitCode = 1;
                continue;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(target)!);
            Move(source, target);
            Console.WriteLine($"{name} -> {padded[..2]}/{name}");
        }

        return exitCode;
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
