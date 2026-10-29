using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LeetCode.Bash;

public abstract partial class BashTestsBase<TBashTests> : TestsBase where TBashTests : BashTestsBase<TBashTests>
{
    [GeneratedRegex("# SkipSolution: (.+)")]
    private static partial Regex SkipSolutionRegex();

    [Test]
    [TestCaseSource(nameof(JoinedTestCases))]
    [Category("Bash")]
    public void Test(string solutionScriptPath, BashTestCase testCase)
    {
        RunTestWithStackAndTimeoutChecks(testCase,
            () => RunBashTestAsync(solutionScriptPath, testCase).GetAwaiter().GetResult());
    }

    private static async Task RunBashTestAsync(string solutionScriptPath, BashTestCase testCase)
    {
        using var tempDir = new TempDir();

        foreach (var (fileName, content) in testCase.Files)
        {
            await File.WriteAllTextAsync($@"{tempDir.Path}\{fileName}", content).ConfigureAwait(true);
        }

        var process = Process.Start(new ProcessStartInfo
        {
            FileName = "bash.exe",
            ArgumentList = { ToLinuxFullPath(solutionScriptPath) },
            WorkingDirectory = tempDir.Path,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        })!;

        var standardOutput = FixLineEnding(await process.StandardOutput.ReadToEndAsync().ConfigureAwait(true));
        var standardError = FixLineEnding(await process.StandardError.ReadToEndAsync().ConfigureAwait(true));
        await process.WaitForExitAsync().ConfigureAwait(true);

        Assert.Multiple(() =>
        {
            Assert.That(standardOutput, Is.EqualTo(testCase.StandardOutput).NoClip, "Standard Output");
            Assert.That(standardError, Is.EqualTo(testCase.StandardError).NoClip, "Standard Error");
        });
    }

    private static string FixLineEnding(string str) => str.Replace("\r", "", StringComparison.Ordinal).TrimEnd('\n');

    private static string ToLinuxFullPath(string solutionScriptPath)
    {
        var fullPath = Path.GetFullPath(solutionScriptPath);
        var driveLetter = fullPath[0];
        var rootPath = fullPath[2..];
        var linuxRootPath = rootPath.Replace('\\', '/');
        var linuxFullPath = $"/mnt/{char.ToLower(driveLetter, CultureInfo.InvariantCulture)}{linuxRootPath}";
        return linuxFullPath;
    }

#pragma warning disable CA1000
    public static IEnumerable<TestCaseData> JoinedTestCases
#pragma warning restore CA1000
    {
        get
        {
            var testCases = GetTestCases<TBashTests, BashTestCase>();
            var problemTestCaseDirectory = GetProblemDirectory(typeof(TBashTests))!;
            var solutionScriptFiles = Directory.GetFiles(problemTestCaseDirectory, "Solution*.sh");

            if (solutionScriptFiles.Length == 0)
            {
                Assert.Fail("No Solution*.sh found");
            }

            foreach (var solutionScriptFile in solutionScriptFiles)
            {
                var solutionName = Path.GetFileNameWithoutExtension(solutionScriptFile);
                var firstLine = File.ReadLines(solutionScriptFile).First();
                var skipSolutionReason = SkipSolutionRegex().Match(firstLine).Groups[1].Value;

                foreach (var testCase in testCases)
                {
                    var testCaseData = new TestCaseData(solutionScriptFile, testCase).SetName($"{solutionName}: {testCase.TestCaseName}");

                    if (!string.IsNullOrEmpty(skipSolutionReason))
                    {
                        testCaseData.Explicit(skipSolutionReason);
                    }

                    yield return testCaseData;
                }
            }
        }
    }
}
