using LeetCodeExporter;

namespace LeetCodeExporter.Tests;

public class SolutionFinderTests
{
    private const string BaseDir = @"C:\repo\src\LeetCode.Problems";

    private static readonly string WipDir = Path.Combine(BaseDir, "!WIP");
    private static string BucketDir(string problemNumber) => Path.Combine(BaseDir, problemNumber[..2]);

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
            OnDirectoryExists = path => path == BucketDir("9999"),
            OnGetDirectories = (_, _) => []
        };
        var finder = new SolutionFinder(fs, BaseDir);

        var result = finder.FindSolutionFile("9999", null);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void FindSolutionFile_SearchesWipDirFirst()
    {
        var wipMatch = Path.Combine(WipDir, "3508 Implement Router");
        var solutionFile = Path.Combine(wipMatch, "Solution1.cs");

        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path is var p && (p == WipDir || p == BucketDir("3508")),
            OnGetDirectories = (parent, pattern) =>
                parent == WipDir && pattern == "3508 *" ? [wipMatch] : [],
            OnGetFiles = (dir, _) =>
                dir == wipMatch ? [solutionFile] : []
        };
        var finder = new SolutionFinder(fs, BaseDir);

        var result = finder.FindSolutionFile("3508", null);

        Assert.That(result, Is.EqualTo(solutionFile));
    }

    [Test]
    public void FindSolutionFile_FallsBackToBucketDir()
    {
        var problemMatch = Path.Combine(BucketDir("3508"), "3508 Implement Router");
        var solutionFile = Path.Combine(problemMatch, "Solution1.cs");

        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path is var p && (p == WipDir || p == BucketDir("3508")),
            OnGetDirectories = (parent, pattern) =>
                parent == BucketDir("3508") && pattern == "3508 *" ? [problemMatch] : [],
            OnGetFiles = (dir, _) =>
                dir == problemMatch ? [solutionFile] : []
        };
        var finder = new SolutionFinder(fs, BaseDir);

        var result = finder.FindSolutionFile("3508", null);

        Assert.That(result, Is.EqualTo(solutionFile));
    }

    [Test]
    public void FindSolutionFile_SkipsWipDir_WhenItDoesNotExist()
    {
        var problemMatch = Path.Combine(BucketDir("3508"), "3508 Implement Router");
        var solutionFile = Path.Combine(problemMatch, "Solution1.cs");

        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path == BucketDir("3508"),
            OnGetDirectories = (parent, pattern) =>
                parent == BucketDir("3508") && pattern == "3508 *" ? [problemMatch] : [],
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
        var problemDir = Path.Combine(BucketDir("0001"), "0001 Two Sum");
        var sol1 = Path.Combine(problemDir, "Solution1.cs");
        var sol2 = Path.Combine(problemDir, "Solution2.cs");
        var sol3 = Path.Combine(problemDir, "Solution3.cs");

        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path == BucketDir("0001"),
            OnGetDirectories = (parent, pattern) =>
                parent == BucketDir("0001") && pattern == "0001 *" ? [problemDir] : [],
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
        var problemDir = Path.Combine(BucketDir("0001"), "0001 Two Sum");
        var sol2 = Path.Combine(problemDir, "Solution2.cs");
        var sol10 = Path.Combine(problemDir, "Solution10.cs");

        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path == BucketDir("0001"),
            OnGetDirectories = (parent, pattern) =>
                parent == BucketDir("0001") && pattern == "0001 *" ? [problemDir] : [],
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
        var problemDir = Path.Combine(BucketDir("0001"), "0001 Two Sum");
        var sol1 = Path.Combine(problemDir, "Solution1.cs");
        var sol2 = Path.Combine(problemDir, "Solution2.cs");
        var sol3 = Path.Combine(problemDir, "Solution3.cs");

        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path == BucketDir("0001"),
            OnGetDirectories = (parent, pattern) =>
                parent == BucketDir("0001") && pattern == "0001 *" ? [problemDir] : [],
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
        var problemDir = Path.Combine(BucketDir("0001"), "0001 Two Sum");
        var sol1 = Path.Combine(problemDir, "Solution1.cs");

        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path == BucketDir("0001"),
            OnGetDirectories = (parent, pattern) =>
                parent == BucketDir("0001") && pattern == "0001 *" ? [problemDir] : [],
            OnGetFiles = (dir, _) =>
                dir == problemDir ? [sol1] : []
        };
        var finder = new SolutionFinder(fs, BaseDir);

        var result = finder.FindSolutionFile("0001", 5);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void FindSolutionFile_PadsShortProblemNumber()
    {
        var problemDir = Path.Combine(BucketDir("0755"), "0755 Pour Water");
        var solutionFile = Path.Combine(problemDir, "Solution1.cs");

        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path == BucketDir("0755"),
            OnGetDirectories = (parent, pattern) =>
                parent == BucketDir("0755") && pattern == "0755 *" ? [problemDir] : [],
            OnGetFiles = (dir, _) =>
                dir == problemDir ? [solutionFile] : []
        };
        var finder = new SolutionFinder(fs, BaseDir);

        var result = finder.FindSolutionFile("755", null);

        Assert.That(result, Is.EqualTo(solutionFile));
    }

    [Test]
    public void FindSolutionFile_ReturnsNull_WhenNoSolutionFilesInDirectory()
    {
        var problemDir = Path.Combine(BucketDir("0001"), "0001 Two Sum");

        var fs = new MockFileSystem
        {
            OnDirectoryExists = path => path == BucketDir("0001"),
            OnGetDirectories = (parent, pattern) =>
                parent == BucketDir("0001") && pattern == "0001 *" ? [problemDir] : [],
            OnGetFiles = (_, _) => []
        };
        var finder = new SolutionFinder(fs, BaseDir);

        var result = finder.FindSolutionFile("0001", null);

        Assert.That(result, Is.Null);
    }
}
