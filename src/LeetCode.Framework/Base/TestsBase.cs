using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime;
using System.Runtime.ExceptionServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using NUnit.Framework.Constraints;

namespace LeetCode.Base;

public abstract class TestsBase<TSolution, TTestCase> : TestsBase where TTestCase : TestCaseBase, new()
{
    [Test]
    [TestCaseSource(nameof(JoinedTestCases))]
    [Category("C#")]
    public void Test(TSolution solution, TTestCase testCase)
    {
        RunTestWithTimeout(testCase, () => TestCore(solution, testCase));
    }

    protected abstract void TestCore(TSolution solution, TTestCase testCase);

    private static IEnumerable<TestCaseData> JoinedTestCases
    {
        get
        {
            var testCases = GetTestCases<TSolution, TTestCase>();
            var solutionInterfaceType = typeof(TSolution);
            var solutionTypes = solutionInterfaceType.Assembly.GetTypes()
                .Where(t => t.IsClass && t.IsAssignableTo(solutionInterfaceType) && !t.IsAbstract);
            var solutions = solutionTypes.Select(t => (TSolution) Activator.CreateInstance(t)!).ToArray();

            if (solutions.Length == 0)
            {
                Assert.Fail("No Solution types found");
            }

            foreach (var solution in solutions)
            {
                foreach (var testCase in testCases)
                {
                    var testCaseData =
                        new TestCaseData(solution, testCase).SetName(
                            $"{solution!.GetType().Name}: {testCase.TestCaseName}");

                    var skipSolutionAttribute =
                        (SkipSolutionAttribute?) Attribute.GetCustomAttribute(solution.GetType(),
                            typeof(SkipSolutionAttribute));

                    if (skipSolutionAttribute != null)
                    {
                        testCaseData.Explicit(skipSolutionAttribute.Reason.ToString());
                    }

                    yield return testCaseData;
                }
            }
        }
    }
}

public abstract class TestsBase
{
    protected static CollectionItemsEqualConstraint IsEquivalentToIgnoringItemOrder<T>(
        IEnumerable<IEnumerable<T>> expected)
    {
        return Is.EquivalentTo(expected)
            .Using<IEnumerable<T>>((a, b) =>
            {
                var aSorted = a.OrderBy(x => x);
                var bSorted = b.OrderBy(x => x);
                return aSorted.SequenceEqual(bSorted);
            });
    }

    private static void AssertEqualWithDetails(object? actual, object? expected, string? message = null)
    {
        if (message != null)
        {
            message += "\r\n";
        }

        if (expected is double[])
        {
            Assert.That(actual, Is.EqualTo(expected).Within(1e-5),
                $"{message}Actual:\r\n{JsonSerializer.Serialize(actual)}\r\n\r\nExpected:\r\n{JsonSerializer.Serialize(expected)}\r\n\r\n");
        }
        else
        {
            Assert.That(actual, Is.EqualTo(expected),
                $"{message}Actual:\r\n{JsonSerializer.Serialize(actual)}\r\n\r\nExpected:\r\n{JsonSerializer.Serialize(expected)}\r\n\r\n");
        }
    }

    protected static void AssertCollectionEqualWithDetails<T>(IEnumerable<T> actual, IEnumerable<T> expected,
        string? message = null)
    {
        if (GetStructuralComparer<T>() is not { } comparer)
        {
            AssertEqualWithDetails(actual.ToArray(), expected.ToArray(), message);
            return;
        }

        var actualArray = actual.ToArray();
        var expectedArray = expected.ToArray();
        Assert.That(actualArray, Is.EqualTo(expectedArray).Using(comparer),
            $"{(message == null ? null : message + "\r\n")}Actual:\r\n{FormatItems(actualArray)}\r\n\r\nExpected:\r\n{FormatItems(expectedArray)}\r\n\r\n");
    }

    protected static void AssertCollectionEquivalentWithDetails<T>(IEnumerable<T> actual, IEnumerable<T> expected)
    {
        var actualArray = actual.ToArray();
        var expectedArray = expected.ToArray();
        if (GetStructuralComparer<T>() is { } comparer)
        {
            Assert.That(actualArray, Is.EquivalentTo(expectedArray).Using(comparer),
                "Actual:\r\n{0}\r\n\r\nExpected:\r\n{1}\r\n\r\n", FormatItems(actualArray), FormatItems(expectedArray));
            return;
        }

        Assert.That(actualArray, Is.EquivalentTo(expectedArray), "Actual:\r\n{0}\r\n\r\nExpected:\r\n{1}\r\n\r\n",
            JsonSerializer.Serialize(actualArray), JsonSerializer.Serialize(expectedArray));
    }

    /// <summary>
    /// Nodes compare by reference, as on LeetCode, so collections of them are compared by structure here instead.
    /// </summary>
    private static IEqualityComparer<T>? GetStructuralComparer<T>()
    {
        if (typeof(T) == typeof(ListNode))
        {
            return (IEqualityComparer<T>) ListNode.StructuralComparer;
        }

        if (typeof(T) == typeof(TreeNode))
        {
            return (IEqualityComparer<T>) TreeNode.StructuralComparer;
        }

        return null;
    }

    // JSON shows a node as {}, its fields being public fields; its ToString shows its values.
    private static string FormatItems<T>(T[] items) => $"[{string.Join(", ", items.Select(item => item?.ToString() ?? "null"))}]";

    protected static void AssertCollectionEquivalentIgnoringItemOrderWithDetails<T>(IEnumerable<IEnumerable<T>> actual,
        IEnumerable<IEnumerable<T>> expected)
    {
        var actualArray = actual.ToArray();
        var expectedArray = expected.ToArray();
        Assert.That(actualArray, IsEquivalentToIgnoringItemOrder(expectedArray),
            "Actual:\r\n{0}\r\n\r\nExpected:\r\n{1}\r\n\r\n", JsonSerializer.Serialize(actualArray),
            JsonSerializer.Serialize(expectedArray));
    }

    /// <summary>
    /// The folder of the problem <paramref name="problemRelatedType"/> belongs to, as recorded at compile time by
    /// the <see cref="ProblemDirectoryAttribute"/>s of its assembly, or <see langword="null"/> when none names
    /// its namespace.
    /// </summary>
    protected static string? GetProblemDirectory(Type problemRelatedType)
    {
        ArgumentNullException.ThrowIfNull(problemRelatedType);

        var directories = ProblemDirectories.GetOrAdd(problemRelatedType.Assembly, ReadProblemDirectories);
        return problemRelatedType.Namespace != null &&
            directories.TryGetValue(problemRelatedType.Namespace, out var relativePath)
                ? Path.GetFullPath(Path.Combine(ProblemsRoot.Value, relativePath))
                : null;
    }

    private static readonly ConcurrentDictionary<Assembly, IReadOnlyDictionary<string, string>> ProblemDirectories =
        new();

    internal static IReadOnlyDictionary<string, string> ReadProblemDirectories(Assembly assembly) =>
        assembly.GetCustomAttributes<ProblemDirectoryAttribute>()
            .ToDictionary(attribute => attribute.NamespaceName, attribute => attribute.RelativePath, StringComparer.Ordinal);

    // Test cases are read from the source tree, so editing one needs no rebuild.
    private static readonly Lazy<string> ProblemsRoot =
        new(() => Path.Combine(FindRepoRoot(), "src", "LeetCode.Problems"));

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

    private static readonly JsonSerializerOptions DeserializeOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
        Converters = { new PlainObjectArrayConverter() },
        TypeInfoResolver = new DefaultJsonTypeInfoResolver
        {
            Modifiers = { AllPropertiesRequiredModifier.MakePropertiesRequired }
        }
    };

    private static TTestCase FromJson<TTestCase>(string testCaseFilePath) where TTestCase : TestCaseBase, new()
    {
        var name = Path.GetFileNameWithoutExtension(testCaseFilePath);

        try
        {
            using var fileStream = File.OpenRead(testCaseFilePath);
            var testCase = JsonSerializer.Deserialize<TTestCase>(fileStream, DeserializeOptions)
                ?? throw new JsonException("Deserialized test case is null");
            testCase.TestCaseName = name;
            return testCase;
        }
#pragma warning disable CA1031
        catch (Exception ex)
#pragma warning restore CA1031
        {
            return new TTestCase
            {
                TestCaseName = name,
                JsonParsingException = ex
            };
        }
    }

    // LeetCode accepts deeply recursive solutions (a 1e5-deep memoized recursion, a 1e5-node skewed tree),
    // and a debug build's frames are large, so 8 MB overflowed. A stack overflow cannot be caught in .NET:
    // it still kills the whole test host, this only makes it rarer.
    // Only the reservation is this size; pages are committed as the stack grows.
    private const int MaxStackSize = 512 * 1024 * 1024;

    private static readonly TimeSpan PollInterval = TimeSpan.FromMilliseconds(20);

    // How long an aborted solution gets to unwind before the test gives up on it.
    private static readonly TimeSpan AbortGracePeriod = TimeSpan.FromSeconds(1);

    /// <summary>
    /// Runs a C# solution on its own thread and budgets the CPU time that thread spends, less the time it spends
    /// in the JIT, so neither a loaded machine nor the first call's compilation times a test out.
    /// A solution that blocks uses no CPU, so wall-clock time is capped too, at <see cref="GetWallClockLimit"/>.
    /// A solution over either budget is aborted with <see cref="ControlledExecution"/>, the one in-process way to
    /// stop a runaway loop; the state it can leave torn is the solution's own.
    /// </summary>
    protected static void RunTestWithTimeout(TestCaseBase testCase, Action testAction)
    {
        ThrowIfInvalid(testCase);

        var budget = TimeSpan.FromMilliseconds(testCase.TimeoutInMilliseconds);
        Exception? exception = null;
        var solutionCpuTime = TimeSpan.Zero;
        ThreadCpuClock? clock = null;
        using var clockReady = new ManualResetEventSlim();
        using var cts = new CancellationTokenSource();

        var thread = new Thread(() =>
        {
            try
            {
                clock = ThreadCpuClock.ForCurrentThread();
            }
#pragma warning disable CA1031
            catch (Exception ex)
#pragma warning restore CA1031
            {
                exception = ex;
                return;
            }
            finally
            {
                clockReady.Set();
            }

            var cpuTimeBefore = clock.Elapsed;
            var jitTimeBefore = JitInfo.GetCompilationTime(currentThread: true);

            try
            {
#pragma warning disable SYSLIB0046
                ControlledExecution.Run(testAction, cts.Token);
#pragma warning restore SYSLIB0046
            }
#pragma warning disable CA1031
            catch (Exception ex)
#pragma warning restore CA1031
            {
                exception = ex;
            }

            solutionCpuTime = clock.Elapsed - cpuTimeBefore
                - (JitInfo.GetCompilationTime(currentThread: true) - jitTimeBefore);
        }, MaxStackSize) { IsBackground = true };

        var processJitTimeBefore = JitInfo.GetCompilationTime();
        var wallClock = Stopwatch.StartNew();
        thread.Start();
        clockReady.Wait();

        if (clock == null)
        {
            thread.Join();
            ExceptionDispatchInfo.Throw(exception!);
        }

        string? timeoutMessage = null;

        if (Debugger.IsAttached)
        {
            // When debugging we want to wait indefinitely to allow inspection
            thread.Join();
        }
        else
        {
            var wallClockLimit = GetWallClockLimit(budget);
            var abortedAt = TimeSpan.Zero;

            while (!thread.Join(PollInterval))
            {
                if (timeoutMessage == null)
                {
                    // The thread's own JIT time is only known to the thread, so the whole process's stands in for it:
                    // it can only be larger, so the watch never aborts a solution the final check would pass.
                    var cpuTime = clock.Elapsed - (JitInfo.GetCompilationTime() - processJitTimeBefore);

                    if (cpuTime > budget)
                    {
                        timeoutMessage = GetCpuTimeoutMessage(testCase);
                    }
                    else if (wallClock.Elapsed > wallClockLimit)
                    {
                        timeoutMessage = $"Test timed out: it ran {wallClockLimit.TotalMilliseconds} milliseconds of " +
                            $"wall-clock time, having used only {cpuTime.TotalMilliseconds:F0} of its " +
                            $"{testCase.TimeoutInMilliseconds} milliseconds of CPU time, so it is blocked";
                    }

                    if (timeoutMessage != null)
                    {
                        abortedAt = wallClock.Elapsed;
                        cts.Cancel();
                    }
                }
                else if (wallClock.Elapsed - abortedAt > AbortGracePeriod)
                {
                    // The abort lands only in managed code; a thread stuck in a native call keeps running.
                    Assert.Fail($"{timeoutMessage}, and it did not stop when aborted");
                }
            }
        }

        clock.Dispose();

        if (timeoutMessage != null)
        {
            Assert.Fail(timeoutMessage);
        }

        if (exception != null)
        {
            ExceptionDispatchInfo.Throw(exception);
        }

        if (!Debugger.IsAttached && solutionCpuTime > budget)
        {
            Assert.Fail(GetCpuTimeoutMessage(testCase));
        }
    }

    /// <summary>
    /// Runs a test whose work happens in another process (bash, SQL Server, Node.js). Its budget is wall-clock time,
    /// and it is stopped by cancelling the token, which the test passes down to that process.
    /// </summary>
    protected static void RunTestWithTimeout(TestCaseBase testCase, Func<CancellationToken, Task> testAction)
    {
        ThrowIfInvalid(testCase);
        ArgumentNullException.ThrowIfNull(testAction);

        using var cts = new CancellationTokenSource();

        if (!Debugger.IsAttached)
        {
            cts.CancelAfter(testCase.TimeoutInMilliseconds);
        }

        try
        {
            Task.Run(() => testAction(cts.Token), CancellationToken.None).GetAwaiter().GetResult();
        }
        // Whatever a cancelled test throws (SqlClient reports a cancel as a SqlException, and the SQL runner wraps
        // that in an assertion), it threw it because it timed out.
#pragma warning disable CA1031
        catch (Exception) when (cts.IsCancellationRequested)
#pragma warning restore CA1031
        {
            Assert.Fail($"Test timed out after {testCase.TimeoutInMilliseconds} milliseconds");
        }
    }

    // Generous, because a solution starved of CPU on a loaded machine needs several times its budget to use it.
    internal static TimeSpan GetWallClockLimit(TimeSpan budget) => budget * 10 + TimeSpan.FromSeconds(5);

    private static string GetCpuTimeoutMessage(TestCaseBase testCase) =>
        $"Test timed out after {testCase.TimeoutInMilliseconds} milliseconds of CPU time";

    private static void ThrowIfInvalid(TestCaseBase testCase)
    {
        ArgumentNullException.ThrowIfNull(testCase);

        if (testCase.JsonParsingException != null)
        {
            Assert.Fail(testCase.JsonParsingException.ToString());
        }
    }

    protected static TTestCase[] GetTestCases<TProblemRelatedType, TTestCase>() where TTestCase : TestCaseBase, new()
    {
        var problemTestCaseDirectory = GetProblemDirectory(typeof(TProblemRelatedType));

        var testCaseFiles = problemTestCaseDirectory == null
            ? Array.Empty<string>()
            : Directory.GetFiles(problemTestCaseDirectory, "TestCase*.json");

        if (testCaseFiles.Length == 0)
        {
            Assert.Fail("No test cases found");
        }

        var testCases = testCaseFiles.Select(FromJson<TTestCase>).ToArray();
        return testCases;
    }
}
