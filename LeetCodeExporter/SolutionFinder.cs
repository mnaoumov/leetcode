namespace LeetCodeExporter;

public static class SolutionFinder
{
    public static string? FindSolutionFile(string problemNumber, int? solutionNumber)
    {
        var baseDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "LeetCode"));
        var searchDirs = new[] { Path.Combine(baseDir, "Problems", "!TODO"), Path.Combine(baseDir, "Problems") };

        string? problemDir = null;

        foreach (var dir in searchDirs)
        {
            if (!Directory.Exists(dir))
            {
                continue;
            }

            var match = Directory.GetDirectories(dir, $"{problemNumber} *").FirstOrDefault();

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

        var solutionFiles = Directory.GetFiles(problemDir, "Solution*.cs")
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
