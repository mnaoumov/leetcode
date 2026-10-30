namespace LeetCode.Framework.Tests;

/// <summary>
/// The problem folders the runners' tests use, under <c>Fixtures</c>. A <see cref="LeetCode.Base.ProblemDirectoryAttribute"/>
/// names one relative to the problems project, as the problems assembly's generator does.
/// </summary>
internal static class Fixtures
{
    public const string RelativeRoot = "../../tests/LeetCode.Framework.Tests/Fixtures";

    public static string GetPath(params string[] parts) =>
        Path.Combine([FindRepoRoot(), "tests", "LeetCode.Framework.Tests", "Fixtures", ..parts]);

    private static string FindRepoRoot()
    {
        for (var dir = new DirectoryInfo(AppContext.BaseDirectory); dir != null; dir = dir.Parent)
        {
            if (File.Exists(Path.Combine(dir.FullName, "LeetCode.slnx")))
            {
                return dir.FullName;
            }
        }

        throw new DirectoryNotFoundException($"No LeetCode.slnx above {AppContext.BaseDirectory}");
    }
}
