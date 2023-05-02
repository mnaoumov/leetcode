using System.Diagnostics;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace LeetCode;

public abstract class BashTestsBase<TBashTests> : TestsBase where TBashTests : BashTestsBase<TBashTests>
{
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
            await File.WriteAllTextAsync($@"{tempDir.Path}\{fileName}", content);
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

        var standardOutput = FixLineEnding(await process.StandardOutput.ReadToEndAsync());
        var standardError = FixLineEnding(await process.StandardError.ReadToEndAsync());
        await process.WaitForExitAsync();

        Assert.Multiple(() =>
        {
            Assert.That(standardOutput, Is.EqualTo(testCase.StandardOutput).NoClip, "Standard Output");
            Assert.That(standardError, Is.EqualTo(testCase.StandardError).NoClip, "Standard Error");
        });
    }

    private static string FixLineEnding(string str) => str.Replace("\r", "").TrimEnd('\n');

    private static string ToLinuxFullPath(string solutionScriptPath)
    {
        var fullPath = Path.GetFullPath(solutionScriptPath);
        var driveLetter = fullPath[0];
        var rootPath = fullPath[2..];
        var linuxRootPath = rootPath.Replace('\\', '/');
        var linuxFullPath = $"/mnt/{char.ToLower(driveLetter)}{linuxRootPath}";
        return linuxFullPath;
    }

    public static IEnumerable<TestCaseData> JoinedTestCases
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
                var skipSolutionReason = Regex.Match(firstLine, "# SkipSolution: (.+)").Groups[1].Value;

                foreach (var testCase in testCases)
                {
                    var testCaseData = new TestCaseData(solutionScriptFile, testCase).SetName($@"{solutionName}: {testCase.TestCaseName}");

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
