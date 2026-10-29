namespace LeetCodeExporter;

public class SolutionFinder
{
    private readonly IFileSystem _fileSystem;
    private readonly string _baseDir;

    public SolutionFinder(IFileSystem fileSystem, string baseDir)
    {
        _fileSystem = fileSystem;
        _baseDir = baseDir;
    }

    public string? FindSolutionFile(string problemNumber, int? solutionNumber)
    {
        var paddedNumber = problemNumber.PadLeft(4, '0');
        var searchDirs = new[] { Path.Combine(_baseDir, "!WIP"), Path.Combine(_baseDir, paddedNumber[..2]) };

        string? problemDir = null;

        foreach (var dir in searchDirs)
        {
            if (!_fileSystem.DirectoryExists(dir))
            {
                continue;
            }

            var match = _fileSystem.GetDirectories(dir, $"{paddedNumber} *").FirstOrDefault();

            if (match != null)
            {
                problemDir = match;
                break;
            }
        }

        if (problemDir == null)
        {
            return null;
        }

        var solutionFiles = _fileSystem.GetFiles(problemDir, "Solution*.cs")
            .OrderBy(SolutionNumber)
            .ToArray();

        if (solutionFiles.Length == 0)
        {
            return null;
        }

        if (solutionNumber.HasValue)
        {
            return solutionFiles.FirstOrDefault(f => SolutionNumber(f) == solutionNumber);
        }

        return solutionFiles.Last();
    }

    // Solution7.cs, Solution07.cs and Solution5_10.cs (one file for solutions 5 and 10) start with their number.
    private static int SolutionNumber(string path) =>
        int.Parse(new string(Path.GetFileNameWithoutExtension(path)["Solution".Length..].TakeWhile(char.IsDigit).ToArray()));
}
