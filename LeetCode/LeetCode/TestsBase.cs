using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace LeetCode;

public abstract class TestsBase<TSolution, TTestCase> where TTestCase : TestCaseBase<TTestCase>, new()
{
    [Test]
    [TestCaseSource(nameof(JoinedTestCases))]
    [Timeout(50)]
    public void Test(TSolution solution, TTestCase testCase)
    {
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

            var testCaseBuilder = new TTestCase();
            var testCases = testCaseBuilder.TestCases.ToArray();

            foreach (var solution in solutions)
            {
                foreach (var testCase in testCases)
                {
                    var testCaseTestCaseName = testCase.TestCaseName ?? $"Test Case {Array.IndexOf(testCases, testCase) + 1}";
                    var testCaseData =
                        new TestCaseData(solution, testCase).SetName(
                            $@"{solution!.GetType().Name}: {testCaseTestCaseName}");
                    if (solution.GetType().Name.StartsWith("Bad"))
                    {
                        testCaseData.Explicit();
                    }

                    yield return testCaseData;
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