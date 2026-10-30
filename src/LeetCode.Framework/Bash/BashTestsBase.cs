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
    public void Test(string solutionScriptPath, string testCaseFilePath)
    {
        var testCase = LoadTestCase<BashTestCase>(testCaseFilePath);
        RunTestWithTimeout(testCase,
            cancellationToken => RunBashTestAsync(solutionScriptPath, testCase, cancellationToken));
    }

    private static async Task RunBashTestAsync(string solutionScriptPath, BashTestCase testCase,
        CancellationToken cancellationToken)
    {
        using var tempDir = new TempDir();

        foreach (var (fileName, content) in testCase.Files)
        {
            await File.WriteAllTextAsync(Path.Combine(tempDir.Path, fileName), content, cancellationToken).ConfigureAwait(true);
        }

        using var process = Process.Start(new ProcessStartInfo
        {
            FileName = "bash.exe",
            ArgumentList = { ToLinuxFullPath(solutionScriptPath) },
            WorkingDirectory = tempDir.Path,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        })!;

        // A timed-out script must not outlive its test, nor must anything it started.
        await using var killOnTimeout = cancellationToken.Register(() => KillProcessTree(process)).ConfigureAwait(true);

        var standardOutput = FixLineEnding(await process.StandardOutput.ReadToEndAsync(cancellationToken).ConfigureAwait(true));
        var standardError = FixLineEnding(await process.StandardError.ReadToEndAsync(cancellationToken).ConfigureAwait(true));
        await process.WaitForExitAsync(cancellationToken).ConfigureAwait(true);

        Assert.Multiple(() =>
        {
            Assert.That(standardOutput, Is.EqualTo(testCase.StandardOutput).NoClip, "Standard Output");
            Assert.That(standardError, Is.EqualTo(testCase.StandardError).NoClip, "Standard Error");
        });
    }

    private static void KillProcessTree(Process process)
    {
        try
        {
            process.Kill(entireProcessTree: true);
        }
        catch (InvalidOperationException)
        {
            // It has already exited.
        }
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
            const int argumentCount = 2;
            var testCaseFiles = GetProblemFiles(typeof(TBashTests), "TestCase*.json");

            if (testCaseFiles.Length == 0)
            {
                yield return DiscoveryFailure("No test cases found", argumentCount);
                yield break;
            }

            var solutionScriptFiles = GetProblemFiles(typeof(TBashTests), "Solution*.sh");

            if (solutionScriptFiles.Length == 0)
            {
                yield return DiscoveryFailure("No Solution*.sh found", argumentCount);
                yield break;
            }

            foreach (var solutionScriptFile in solutionScriptFiles)
            {
                var solutionName = Path.GetFileNameWithoutExtension(solutionScriptFile);
                var skipSolutionReason = SkipSolutionRegex().Match(ReadFirstLine(solutionScriptFile)).Groups[1].Value;

                foreach (var testCaseFile in testCaseFiles)
                {
                    var testCaseData = new TestCaseData(solutionScriptFile, testCaseFile)
                        .SetName($"{solutionName}: {Path.GetFileNameWithoutExtension(testCaseFile)}");

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
