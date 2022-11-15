using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;
using Newtonsoft.Json;

namespace LeetCode;

public abstract class TestsBase<TSolution, TTestCase> where TTestCase : TestCaseBase, new()
{
    [Test]
    [TestCaseSource(nameof(JoinedTestCases))]
    public void Test(TSolution solution, TTestCase testCase)
    {
        if (testCase.JsonParsingException != null)
        {
            Assert.Fail(testCase.JsonParsingException.ToString());
        }

        TestImpl(solution, testCase);
    }

    protected abstract void TestImpl(TSolution solution, TTestCase testCase);

    private static IEnumerable<TestCaseData> JoinedTestCases
    {
        get
        {
            var solutionInterfaceType = typeof(TSolution);
            var solutionTypes = solutionInterfaceType.Assembly.GetTypes().Where(t => t.IsClass && t.IsAssignableTo(solutionInterfaceType));
            var solutions = solutionTypes.Select(t => (TSolution)Activator.CreateInstance(t)!);

            var problemNumber = Regex.Match(solutionInterfaceType.Namespace!, @"LeetCode\._(\d+)").Groups[1].Value;

            var problemTestCaseDirectory = Directory.GetDirectories(".", $"{problemNumber} *").FirstOrDefault();

            if (problemTestCaseDirectory == null)
            {
                yield break;
            }

            var testCaseFiles = Directory.GetFiles(problemTestCaseDirectory, "TestCase*.json");
            var testCases = testCaseFiles.Select(FromJson).ToArray();

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

                    testCaseData.Properties.Add(PropertyNames.Timeout, testCase.TimeoutInMilliseconds);

                    yield return testCaseData;
                }
            }
        }
    }

    private static TTestCase FromJson(string testCaseFilePath)
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
                ContractResolver = new AllPropertiesRequiredContractResolver()
            };

            var testCase = (TTestCase) serializer.Deserialize(jr, typeof(TTestCase));
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

    protected static CollectionItemsEqualConstraint IsEquivalentToIgnoringItemOrder<T>(IEnumerable<IEnumerable<T>> expected)
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
        Assert.That(actualArray, Is.EqualTo(expectedArray), "Actual:\r\n{0}\r\n\r\nExpected:\r\n{1}\r\n\r\n", JsonConvert.SerializeObject(actualArray), JsonConvert.SerializeObject(expectedArray));
    }

    protected static void AssertCollectionEquivalentWithDetails<T>(IEnumerable<T> actual, IEnumerable<T> expected)
    {
        var actualArray = actual.ToArray();
        var expectedArray = expected.ToArray();
        Assert.That(actualArray, Is.EquivalentTo(expectedArray), "Actual:\r\n{0}\r\n\r\nExpected:\r\n{1}\r\n\r\n", JsonConvert.SerializeObject(actualArray), JsonConvert.SerializeObject(expectedArray));
    }

    protected static void AssertCollectionEquivalentIgnoringItemOrderWithDetails<T>(IEnumerable<IEnumerable<T>> actual, IEnumerable<IEnumerable<T>> expected)
    {
        var actualArray = actual.ToArray();
        var expectedArray = expected.ToArray();
        Assert.That(actualArray, IsEquivalentToIgnoringItemOrder(expectedArray), "Actual:\r\n{0}\r\n\r\nExpected:\r\n{1}\r\n\r\n", JsonConvert.SerializeObject(actualArray), JsonConvert.SerializeObject(expectedArray));
    }

    protected static void TestSut<T>(TSolution solution, SutTestCase testCase)
    {
        var createMethod = solution!.GetType().GetMethod("Create")!;
        var sut = CastAndInvoke(createMethod, solution, testCase.Parameters[0]);

        var methodMap = typeof(T).GetMethods().ToDictionary(x => x.Name);

        for (var i = 1; i < testCase.Commands.Length; i++)
        {
            var command = testCase.Commands[i];
            var methodName = ToPascalCase(command);
            var parameters = testCase.Parameters[i];
            var expected = testCase.Output[i];

            if (!methodMap.ContainsKey(methodName))
            {
                Assert.Fail($"Unknown command '{command}'");
            }

            var actual = CastAndInvoke(methodMap[methodName], sut, parameters);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    private static object? CastAndInvoke(MethodBase methodInfo, object? @this, IEnumerable<object> parameters)
    {
        var parameterTypes = methodInfo.GetParameters().Select(p=>p.ParameterType).ToArray();
        var castedParameters = parameters.Zip(parameterTypes, Convert.ChangeType).ToArray();
        return methodInfo.Invoke(@this, castedParameters);
    }

    private static string ToPascalCase(string command)
    {
        var sb = new StringBuilder(command);
        sb[0] = char.ToUpper(sb[0]);
        return sb.ToString();
    }
}