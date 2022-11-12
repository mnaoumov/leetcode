using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;

namespace LeetCode;

public abstract class TestsBase<TSolution, TTestCase> where TTestCase : TestCaseBase<TTestCase>, new()
{
    [Test]
    [TestCaseSource(nameof(JoinedTestCases))]
    public void Test(TSolution solution, TestCaseBuilder<TTestCase> testCaseBuilder)
    {
        TestImpl(solution, testCaseBuilder.TestCaseFunc());
    }

    protected abstract void TestImpl(TSolution solution, TTestCase testCase);

    private static IEnumerable<TestCaseData> JoinedTestCases
    {
        get
        {
            var solutionInterfaceType = typeof(TSolution);
            var solutionTypes = solutionInterfaceType.Assembly.GetTypes().Where(t => t.IsClass && t.IsAssignableTo(solutionInterfaceType));
            var solutions = solutionTypes.Select(t => (TSolution)Activator.CreateInstance(t)!);

            var testCaseBuilders = new TTestCase().TestCaseBuilders.ToArray();

            foreach (var solution in solutions)
            {
                var testCaseIndex = 0;
                var testCaseNames = new HashSet<string>();
                foreach (var testCaseBuilder in testCaseBuilders)
                {
                    if (string.IsNullOrEmpty(testCaseBuilder.TestCaseName))
                    {
                        throw new Exception($"Test case #{testCaseIndex} does not have mandatory TestCaseName");
                    }

                    if (!testCaseNames.Add(testCaseBuilder.TestCaseName))
                    {
                        throw new Exception($"Test case name '{testCaseBuilder.TestCaseName}' is duplicated");
                    }

                    var testCaseTestCaseName = testCaseBuilder.TestCaseName;
                    var testCaseData =
                        new TestCaseData(solution, testCaseBuilder).SetName(
                            $@"{solution!.GetType().Name}: {testCaseTestCaseName}");
                    var skipSolutionAttribute =
                        (SkipSolutionAttribute?) Attribute.GetCustomAttribute(solution.GetType(),
                            typeof(SkipSolutionAttribute));

                    if (skipSolutionAttribute != null)
                    {
                        testCaseData.Explicit(skipSolutionAttribute.Reason.ToString());
                    }

                    testCaseData.Properties.Add(PropertyNames.Timeout, testCaseBuilder.Timeout.Milliseconds);

                    yield return testCaseData;
                    testCaseIndex++;
                }
            }
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
        Assert.That(actual, Is.EqualTo(expected), "Actual:\r\n{0}\r\n\r\nExpected:\r\n{1}\r\n\r\n", JsonConvert.SerializeObject(actual), JsonConvert.SerializeObject(expected));
    }

    protected static void AssertCollectionEquivalentWithDetails<T>(IEnumerable<T> actual, IEnumerable<T> expected)
    {
        Assert.That(actual, Is.EquivalentTo(expected), "Actual:\r\n{0}\r\n\r\nExpected:\r\n{1}\r\n\r\n", JsonConvert.SerializeObject(actual), JsonConvert.SerializeObject(expected));
    }

    protected static void AssertCollectionEquivalentIgnoringItemOrderWithDetails<T>(IEnumerable<IEnumerable<T>> actual, IEnumerable<IEnumerable<T>> expected)
    {
        Assert.That(actual, IsEquivalentToIgnoringItemOrder(expected), "Actual:\r\n{0}\r\n\r\nExpected:\r\n{1}\r\n\r\n", JsonConvert.SerializeObject(actual), JsonConvert.SerializeObject(expected));
    }
}