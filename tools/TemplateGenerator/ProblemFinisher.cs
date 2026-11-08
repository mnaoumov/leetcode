using System.Text.RegularExpressions;

namespace TemplateGenerator;

/// <summary>
/// Moves finished problems from <c>!WIP/NNNN Title</c> to their bucket, <c>NN/NNNN Title</c>. The bucket is searched by
/// problem number, so a folder stored under another title still counts as the destination. When one is there, the
/// choice is asked for: merge, overwrite after a diff, or skip.
/// </summary>
internal sealed partial class ProblemFinisher
{
    [GeneratedRegex(@"^(\d{4}) ")]
    private static partial Regex ProblemFolderRegex();

    private const int BucketPrefixLength = 2;
    private const string WipFolderName = "!WIP";

    private readonly TextWriter _error;
    private readonly TextReader _input;
    private readonly Action<string, string> _moveFolder;
    private readonly TextWriter _output;
    private readonly string _problemsFolderPath;
    private readonly Action<string, string> _showDiff;

    public ProblemFinisher(
        string problemsFolderPath,
        Action<string, string> moveFolder,
        Action<string, string> showDiff,
        TextReader input,
        TextWriter output,
        TextWriter error)
    {
        _problemsFolderPath = problemsFolderPath;
        _moveFolder = moveFolder;
        _showDiff = showDiff;
        _input = input;
        _output = output;
        _error = error;
    }

    private enum Outcome
    {
        Moved,
        Merged,
        Overwritten,
        Skipped,
        Failed
    }

    private string WipFolderPath => Path.Combine(_problemsFolderPath, WipFolderName);

    /// <summary>
    /// Finishes the given problems; with no numbers, lists the <c>!WIP</c> problems and asks which.
    /// </summary>
    /// <returns>The process exit code: non-zero when any problem failed.</returns>
    public int Finish(int[] numbers)
    {
        var wipFolders = Directory.GetDirectories(WipFolderPath)
            .Select(Path.GetFileName)
            .OfType<string>()
            .Where(name => ProblemFolderRegex().IsMatch(name))
            .Order()
            .ToArray();

        if (numbers.Length == 0)
        {
            if (wipFolders.Length == 0)
            {
                _output.WriteLine("!WIP holds no numbered problems.");
                return 0;
            }

            foreach (var name in wipFolders)
            {
                _output.WriteLine(name);
            }

            _output.Write("Enter problem numbers to finish, separated by spaces: ");
            numbers = (_input.ReadLine() ?? throw new InvalidOperationException("Unexpected end of input"))
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        var outcomes = numbers.Distinct().Select(number => FinishOne(number, wipFolders)).ToArray();
        var failed = outcomes.Count(outcome => outcome == Outcome.Failed);
        _output.WriteLine(
            $"Finished: moved {Count(outcomes, Outcome.Moved)}, merged {Count(outcomes, Outcome.Merged)}, "
            + $"overwritten {Count(outcomes, Outcome.Overwritten)}, skipped {Count(outcomes, Outcome.Skipped)}, failed {failed}");
        return failed == 0 ? 0 : 1;
    }

    private static int Count(Outcome[] outcomes, Outcome outcome)
    {
        return outcomes.Count(candidate => candidate == outcome);
    }

    private Outcome FinishOne(int number, string[] wipFolders)
    {
        var padded = number.ToString("D4");
        var name = wipFolders.SingleOrDefault(folder => ProblemFolderRegex().Match(folder).Groups[1].Value == padded);

        if (name == null)
        {
            _error.WriteLine($"{padded}: FAILED - no !WIP/{padded} folder");
            return Outcome.Failed;
        }

        var bucket = Path.Combine(_problemsFolderPath, padded[..BucketPrefixLength]);
        var source = Path.Combine(WipFolderPath, name);
        var target = Path.Combine(bucket, name);
        var existing = Directory.Exists(bucket) ? Directory.GetDirectories(bucket, $"{padded} *").Order().ToArray() : [];

        try
        {
            if (existing.Length == 0)
            {
                Directory.CreateDirectory(bucket);
                _moveFolder(source, target);
                _output.WriteLine($"{name} -> {Relative(target)}");
                return Outcome.Moved;
            }

            return ResolveConflict(padded, source, target, existing);
        }
        catch (Exception exception) when (exception is IOException or UnauthorizedAccessException)
        {
            _error.WriteLine($"{padded}: FAILED - {exception.Message}");
            return Outcome.Failed;
        }
    }

    private Outcome ResolveConflict(string padded, string source, string target, string[] existing)
    {
        var existingNames = string.Join(", ", existing.Select(Relative));

        if (existing.Length > 1)
        {
            _error.WriteLine($"{padded}: FAILED - the bucket holds several folders for this number: {existingNames}; left in !WIP");
            return Outcome.Failed;
        }

        _error.WriteLine($"{padded}: {existingNames} already exists, so {Relative(source)} was not moved");
        var destination = existing[0];

        return Ask("[m]erge into it, [o]verwrite it after a diff, or [s]kip", ["merge", "overwrite", "skip"]) switch
        {
            "merge" => Merge(padded, source, destination),
            "overwrite" => Overwrite(padded, source, target, destination),
            "skip" => Skip(padded, source),
            _ => NoAnswer(padded, source)
        };
    }

    private Outcome Merge(string padded, string source, string destination)
    {
        if (Directory.GetDirectories(source).Length > 0)
        {
            _error.WriteLine($"{padded}: FAILED - {Relative(source)} has subfolders, which a merge does not cover; left in !WIP");
            return Outcome.Failed;
        }

        var files = Directory.GetFiles(source)
            .Select(path => new GeneratedFile(Path.GetFileName(path), File.ReadAllText(path)))
            .ToArray();
        new ProblemPlacer(_problemsFolderPath, _moveFolder, _output).MergeFinished(destination, files);
        Directory.Delete(source, true);
        _output.WriteLine($"{Relative(source)} merged into {Relative(destination)}");
        return Outcome.Merged;
    }

    private Outcome Overwrite(string padded, string source, string target, string destination)
    {
        _showDiff(destination, source);

        if (Ask($"Delete {Relative(destination)} and move {Relative(source)} there? [y]es or [n]o", ["yes", "no"]) != "yes")
        {
            return Skip(padded, source);
        }

        Directory.Delete(destination, true);
        _moveFolder(source, target);
        _output.WriteLine($"{Relative(source)} -> {Relative(target)}, replacing {Relative(destination)}");
        return Outcome.Overwritten;
    }

    private Outcome Skip(string padded, string source)
    {
        _error.WriteLine($"{padded}: skipped; {Relative(source)} stays where it is");
        return Outcome.Skipped;
    }

    private Outcome NoAnswer(string padded, string source)
    {
        _error.WriteLine($"{padded}: FAILED - no answer on the input; {Relative(source)} stays where it is");
        return Outcome.Failed;
    }

    /// <summary>
    /// Asks until the answer is a choice or its first letter.
    /// </summary>
    /// <returns>The choice, or <c>null</c> when the input has ended.</returns>
    private string? Ask(string prompt, string[] choices)
    {
        while (true)
        {
            _output.Write($"{prompt}: ");
            var answer = _input.ReadLine()?.Trim();

            if (answer == null)
            {
                return null;
            }

            var choice = choices.FirstOrDefault(candidate =>
                answer.Length > 0
                && (candidate.Equals(answer, StringComparison.OrdinalIgnoreCase)
                    || (answer.Length == 1 && char.ToLowerInvariant(answer[0]) == candidate[0])));

            if (choice != null)
            {
                return choice;
            }
        }
    }

    private string Relative(string path)
    {
        return Path.GetRelativePath(_problemsFolderPath, path).Replace('\\', '/');
    }
}
