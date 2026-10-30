using System.Diagnostics;
using System.Globalization;

namespace LeetCode.Bash;

public abstract class BashTestsBase<TBashTests> : TestsBase where TBashTests : BashTestsBase<TBashTests>
{
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

        // Both pipes are drained at once: reading one to its end first deadlocks once the script fills the other.
        var standardOutputTask = process.StandardOutput.ReadToEndAsync(cancellationToken);
        var standardErrorTask = process.StandardError.ReadToEndAsync(cancellationToken);
        await Task.WhenAll(standardOutputTask, standardErrorTask).ConfigureAwait(true);
        var standardOutput = FixLineEnding(await standardOutputTask.ConfigureAwait(true));
        var standardError = FixLineEnding(await standardErrorTask.ConfigureAwait(true));
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
                foreach (var testCaseData in JoinScriptTestCases(solutionScriptFile, "#", testCaseFiles, argumentCount,
                             testCaseFile => [solutionScriptFile, testCaseFile]))
                {
                    yield return testCaseData;
                }
            }
        }
    }
}
