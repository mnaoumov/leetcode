using System.Diagnostics;
using System.Runtime;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using NUnit.Framework.Constraints;

namespace LeetCode.Base;

public abstract class TestsBase<TSolution, TTestCase> : TestsBase where TTestCase : TestCaseBase, new()
{
    [Test]
    [TestCaseSource(nameof(JoinedTestCases))]
    [Category("C#")]
    public void Test(TSolution solution, TTestCase testCase)
    {
        RunTestWithStackAndTimeoutChecks(testCase, () => TestCore(solution, testCase));
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

public abstract partial class TestsBase
{
    [GeneratedRegex(@"[ ()'&\-,%`‑]")]
    private static partial Regex CharactersToEscapeRegex();

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

        Assert.That(actual, Is.EqualTo(expected),
            $"{message}Actual:\r\n{JsonConvert.SerializeObject(actual)}\r\n\r\nExpected:\r\n{JsonConvert.SerializeObject(expected)}\r\n\r\n");
    }

    protected static void AssertCollectionEqualWithDetails<T>(IEnumerable<T> actual, IEnumerable<T> expected,
        string? message = null) => AssertEqualWithDetails(actual.ToArray(), expected.ToArray(), message);

    protected static void AssertCollectionEquivalentWithDetails<T>(IEnumerable<T> actual, IEnumerable<T> expected)
    {
        var actualArray = actual.ToArray();
        var expectedArray = expected.ToArray();
        Assert.That(actualArray, Is.EquivalentTo(expectedArray), "Actual:\r\n{0}\r\n\r\nExpected:\r\n{1}\r\n\r\n",
            JsonConvert.SerializeObject(actualArray), JsonConvert.SerializeObject(expectedArray));
    }

    protected static void AssertCollectionEquivalentIgnoringItemOrderWithDetails<T>(IEnumerable<IEnumerable<T>> actual,
        IEnumerable<IEnumerable<T>> expected)
    {
        var actualArray = actual.ToArray();
        var expectedArray = expected.ToArray();
        Assert.That(actualArray, IsEquivalentToIgnoringItemOrder(expectedArray),
            "Actual:\r\n{0}\r\n\r\nExpected:\r\n{1}\r\n\r\n", JsonConvert.SerializeObject(actualArray),
            JsonConvert.SerializeObject(expectedArray));
    }

    protected static string? GetProblemDirectory(Type problemRelatedType)
    {
        var namespacePart = problemRelatedType.Namespace!.Replace("LeetCode.Problems._", "", StringComparison.Ordinal);
        var problemNumber = namespacePart.Split('_')[0];
        return GetProblemDirectory(problemNumber, namespacePart, "Problems\\!TODO") ?? GetProblemDirectory(problemNumber, namespacePart, "Problems");
    }

    private static string? GetProblemDirectory(string problemNumber, string namespacePart, string dirName)
    {
        var problemTestCaseDirectory = Directory.GetDirectories(dirName, $"{problemNumber} *").FirstOrDefault(dir =>
        {
            var name = dir.Split('\\')[^1];
            var escapedName = CharactersToEscapeRegex().Replace(name, "_");
            return escapedName == namespacePart;
        });

        return problemTestCaseDirectory == null ? null : Path.GetFullPath(problemTestCaseDirectory);
    }

    private static TTestCase FromJson<TTestCase>(string testCaseFilePath) where TTestCase : TestCaseBase, new()
    {
        var name = Path.GetFileNameWithoutExtension(testCaseFilePath);

        try
        {
            using var fileStream = File.OpenRead(testCaseFilePath);
            using var reader = new StreamReader(fileStream);
            using var jr = new JsonTextReader(reader);

            var serializer = new JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Error,
                ContractResolver = new AllPropertiesRequiredContractResolver(),
                Converters = { new PlainObjectArrayConverter() }
            };

            var testCase = serializer.Deserialize<TTestCase>(jr)!;
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

    protected static void RunTestWithStackAndTimeoutChecks(TestCaseBase testCase, Action testAction)
    {
        ArgumentNullException.ThrowIfNull(testCase);

        if (testCase.JsonParsingException != null)
        {
            Assert.Fail(testCase.JsonParsingException.ToString());
        }

        Exception? exception = null;

        const int maxStackSize = 8 * 1024 * 1024;
        AppContext.SetData("GCHeapHardLimit", maxStackSize);
        GC.RefreshMemoryLimit();

        var thread = new Thread(() =>
        {
            try
            {
                using var cts = new CancellationTokenSource();

                if (!Debugger.IsAttached)
                {
                    cts.CancelAfter(testCase.TimeoutInMilliseconds);
                }

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
        }, maxStackSize) { IsBackground = true };
        thread.Start();

        if (Debugger.IsAttached)
        {
            // When debugging we want to wait indefinitely to allow inspection
            thread.Join();
        }
        else
        {
            // Wait for the thread to finish with a safety margin. If it doesn't stop, fail the test.
            // Add a small buffer to the configured timeout to allow cleanup inside the thread.
            var waitTimeout = testCase.TimeoutInMilliseconds + 1000;
            if (!thread.Join(waitTimeout))
            {
                Assert.Fail($"Test timed out after {testCase.TimeoutInMilliseconds} milliseconds");
            }
        }

        switch (exception)
        {
            case null:
                return;
            case OperationCanceledException:
                Assert.Fail($"Test timed out after {testCase.TimeoutInMilliseconds} milliseconds");
                break;
            default:
                ExceptionDispatchInfo.Throw(exception);
                break;
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
