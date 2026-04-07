using LeetCodeExporter;

namespace LeetCodeExporter.Tests;

public class SolutionFinderTests
{
    private const string BaseDir = @"C:\repo\LeetCode";

    private static readonly string TodoDir = Path.Combine(BaseDir, "Problems", "!TODO");
    private static readonly string ProblemsDir = Path.Combine(BaseDir, "Problems");

    [Test]
    public void FindSolutionFile_ReturnsNull_WhenNoDirectoriesExist()
    {
        var fs = new MockFileSystem();
        var finder = new SolutionFinder(fs, BaseDir);

        var result = finder.FindSolutionFile("3508", null);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void FindSolutionFile_ReturnsNull_WhenNoProblemDirectoryMatches()
    {
        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path == ProblemsDir,
            OnGetDirectories = (_, _) => []
        };
        var finder = new SolutionFinder(fs, BaseDir);

        var result = finder.FindSolutionFile("9999", null);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void FindSolutionFile_SearchesTodoDirFirst()
    {
        var todoMatch = Path.Combine(TodoDir, "3508 Implement Router");
        var solutionFile = Path.Combine(todoMatch, "Solution1.cs");

        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path is var p && (p == TodoDir || p == ProblemsDir),
            OnGetDirectories = (parent, pattern) =>
                parent == TodoDir && pattern == "3508 *" ? [todoMatch] : [],
            OnGetFiles = (dir, _) =>
                dir == todoMatch ? [solutionFile] : []
        };
        var finder = new SolutionFinder(fs, BaseDir);

        var result = finder.FindSolutionFile("3508", null);

        Assert.That(result, Is.EqualTo(solutionFile));
    }

    [Test]
    public void FindSolutionFile_FallsBackToProblemsDir()
    {
        var problemMatch = Path.Combine(ProblemsDir, "3508 Implement Router");
        var solutionFile = Path.Combine(problemMatch, "Solution1.cs");

        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path is var p && (p == TodoDir || p == ProblemsDir),
            OnGetDirectories = (parent, pattern) =>
                parent == ProblemsDir && pattern == "3508 *" ? [problemMatch] : [],
            OnGetFiles = (dir, _) =>
                dir == problemMatch ? [solutionFile] : []
        };
        var finder = new SolutionFinder(fs, BaseDir);

        var result = finder.FindSolutionFile("3508", null);

        Assert.That(result, Is.EqualTo(solutionFile));
    }

    [Test]
    public void FindSolutionFile_SkipsTodoDir_WhenItDoesNotExist()
    {
        var problemMatch = Path.Combine(ProblemsDir, "3508 Implement Router");
        var solutionFile = Path.Combine(problemMatch, "Solution1.cs");

        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path == ProblemsDir,
            OnGetDirectories = (parent, pattern) =>
                parent == ProblemsDir && pattern == "3508 *" ? [problemMatch] : [],
            OnGetFiles = (dir, _) =>
                dir == problemMatch ? [solutionFile] : []
        };
        var finder = new SolutionFinder(fs, BaseDir);

        var result = finder.FindSolutionFile("3508", null);

        Assert.That(result, Is.EqualTo(solutionFile));
    }

    [Test]
    public void FindSolutionFile_ReturnsHighestSolution_WhenNoSolutionSpecified()
    {
        var problemDir = Path.Combine(ProblemsDir, "0001 Two Sum");
        var sol1 = Path.Combine(problemDir, "Solution1.cs");
        var sol2 = Path.Combine(problemDir, "Solution2.cs");
        var sol3 = Path.Combine(problemDir, "Solution3.cs");

        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path == ProblemsDir,
            OnGetDirectories = (parent, pattern) =>
                parent == ProblemsDir && pattern == "0001 *" ? [problemDir] : [],
            OnGetFiles = (dir, _) =>
                dir == problemDir ? [sol1, sol3, sol2] : []
        };
        var finder = new SolutionFinder(fs, BaseDir);

        var result = finder.FindSolutionFile("0001", null);

        Assert.That(result, Is.EqualTo(sol3));
    }

    [Test]
    public void FindSolutionFile_SortsNumerically_NotLexicographically()
    {
        var problemDir = Path.Combine(ProblemsDir, "0001 Two Sum");
        var sol2 = Path.Combine(problemDir, "Solution2.cs");
        var sol10 = Path.Combine(problemDir, "Solution10.cs");

        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path == ProblemsDir,
            OnGetDirectories = (parent, pattern) =>
                parent == ProblemsDir && pattern == "0001 *" ? [problemDir] : [],
            OnGetFiles = (dir, _) =>
                dir == problemDir ? [sol10, sol2] : []
        };
        var finder = new SolutionFinder(fs, BaseDir);

        var result = finder.FindSolutionFile("0001", null);

        Assert.That(result, Is.EqualTo(sol10));
    }

    [Test]
    public void FindSolutionFile_ReturnsSpecificSolution_WhenRequested()
    {
        var problemDir = Path.Combine(ProblemsDir, "0001 Two Sum");
        var sol1 = Path.Combine(problemDir, "Solution1.cs");
        var sol2 = Path.Combine(problemDir, "Solution2.cs");
        var sol3 = Path.Combine(problemDir, "Solution3.cs");

        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path == ProblemsDir,
            OnGetDirectories = (parent, pattern) =>
                parent == ProblemsDir && pattern == "0001 *" ? [problemDir] : [],
            OnGetFiles = (dir, _) =>
                dir == problemDir ? [sol1, sol2, sol3] : []
        };
        var finder = new SolutionFinder(fs, BaseDir);

        var result = finder.FindSolutionFile("0001", 2);

        Assert.That(result, Is.EqualTo(sol2));
    }

    [Test]
    public void FindSolutionFile_ReturnsNull_WhenRequestedSolutionDoesNotExist()
    {
        var problemDir = Path.Combine(ProblemsDir, "0001 Two Sum");
        var sol1 = Path.Combine(problemDir, "Solution1.cs");

        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path == ProblemsDir,
            OnGetDirectories = (parent, pattern) =>
                parent == ProblemsDir && pattern == "0001 *" ? [problemDir] : [],
            OnGetFiles = (dir, _) =>
                dir == problemDir ? [sol1] : []
        };
        var finder = new SolutionFinder(fs, BaseDir);

        var result = finder.FindSolutionFile("0001", 5);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void FindSolutionFile_ReturnsNull_WhenNoSolutionFilesInDirectory()
    {
        var problemDir = Path.Combine(ProblemsDir, "0001 Two Sum");

        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path == ProblemsDir,
            OnGetDirectories = (parent, pattern) =>
                parent == ProblemsDir && pattern == "0001 *" ? [problemDir] : [],
            OnGetFiles = (_, _) => []
        };
        var finder = new SolutionFinder(fs, BaseDir);

        var result = finder.FindSolutionFile("0001", null);

        Assert.That(result, Is.Null);
    }
}
