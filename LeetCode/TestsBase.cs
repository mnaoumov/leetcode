using System.Diagnostics;
using System.Runtime.ExceptionServices;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace LeetCode;

public abstract class TestsBase<TSolution, TTestCase> : TestsBase where TTestCase : TestCaseBase, new()
{
    [Test]
    [TestCaseSource(nameof(JoinedTestCases))]
    public void Test(TSolution solution, TTestCase testCase)
    {
        if (testCase.JsonParsingException != null)
        {
            Assert.Fail(testCase.JsonParsingException.ToString());
        }

        Exception? exception = null;

        const int maxStackSize = 8 * 1024 * 1024;

        var thread = new Thread(() =>
        {
            try
            {
                TestImpl(solution, testCase);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }, maxStackSize);
        thread.Start();

        if (!Debugger.IsAttached)
        {
            Assert.That(thread.Join(testCase.TimeoutInMilliseconds), Is.True,
                $"Test timed out after {testCase.TimeoutInMilliseconds} milliseconds");
        }
        else
        {
            thread.Join();
        }

        if (exception != null)
        {
            ExceptionDispatchInfo.Throw(exception);
        }
    }

    protected abstract void TestImpl(TSolution solution, TTestCase testCase);

    private static IEnumerable<TestCaseData> JoinedTestCases
    {
        get
        {
            var solutionInterfaceType = typeof(TSolution);
            var solutionTypes = solutionInterfaceType.Assembly.GetTypes()
                .Where(t => t.IsClass && t.IsAssignableTo(solutionInterfaceType) && !t.IsAbstract);
            var solutions = solutionTypes.Select(t => (TSolution) Activator.CreateInstance(t)!);

            var problemTestCaseDirectory = GetProblemDirectory(solutionInterfaceType);

            if (problemTestCaseDirectory == null)
            {
                yield break;
            }

            var testCaseFiles = Directory.GetFiles(problemTestCaseDirectory, "TestCase*.json");
            var testCases = testCaseFiles.Select(FromJson<TTestCase>).ToArray();

            foreach (var solution in solutions)
            {
                foreach (var testCase in testCases)
                {
                    var testCaseData =
                        new TestCaseData(solution, testCase).SetName(
                            $@"{solution!.GetType().Name}: {testCase.TestCaseName}");

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

    protected static void AssertCollectionEqualWithDetails<T>(IEnumerable<T> actual, IEnumerable<T> expected)
    {
        var actualArray = actual.ToArray();
        var expectedArray = expected.ToArray();
        Assert.That(actualArray, Is.EqualTo(expectedArray), "Actual:\r\n{0}\r\n\r\nExpected:\r\n{1}\r\n\r\n",
            JsonConvert.SerializeObject(actualArray), JsonConvert.SerializeObject(expectedArray));
    }

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
        var problemNumber = Regex.Match(problemRelatedType.Namespace!, @"LeetCode\._(\d+)").Groups[1].Value;
        var problemTestCaseDirectory = Directory.GetDirectories(".", $"{problemNumber} *").FirstOrDefault();
        return problemTestCaseDirectory;
    }

    protected static TTestCase FromJson<TTestCase>(string testCaseFilePath) where TTestCase : TestCaseBase, new()
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

            var testCase = (TTestCase) serializer.Deserialize(jr, typeof(TTestCase))!;
            testCase.TestCaseName = name;
            return testCase;
        }
        catch (Exception ex)
        {
            return new TTestCase
            {
                TestCaseName = name,
                JsonParsingException = ex
            };
        }
    }
}
