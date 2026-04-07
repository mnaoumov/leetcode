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
        var searchDirs = new[] { Path.Combine(_baseDir, "Problems", "!TODO"), Path.Combine(_baseDir, "Problems") };

        string? problemDir = null;

        foreach (var dir in searchDirs)
        {
            if (!_fileSystem.DirectoryExists(dir))
            {
                continue;
            }

            var match = _fileSystem.GetDirectories(dir, $"{problemNumber} *").FirstOrDefault();

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
            .OrderBy(f => int.Parse(Path.GetFileNameWithoutExtension(f).Replace("Solution", "")))
            .ToArray();

        if (solutionFiles.Length == 0)
        {
            return null;
        }

        if (solutionNumber.HasValue)
        {
            return solutionFiles.FirstOrDefault(f => Path.GetFileName(f) == $"Solution{solutionNumber}.cs");
        }

        return solutionFiles.Last();
    }
}
