﻿using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace LeetCode;

public abstract class TestsBase2<TSolution, TTestCase> where TTestCase : TestCaseBase<TTestCase>, new()
{
    [Test]
    [TestCaseSource(nameof(JoinedTestCases))]
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
                    yield return new TestCaseData(solution, testCase).SetName($@"{solution.GetType().Name}: {testCaseTestCaseName}");
                }
            }
        }
    }

    protected static CollectionItemsEqualConstraint IsEquivalentToIgnoringItemOrder<T>(IEnumerable<IEnumerable<T>> expected)
    {
        return Is.EquivalentTo(expected)
            .Using<IEnumerable<T>>((a, b) =>
            {
                var aSorted = a.OrderBy<T, T>(x => x);
                var bSorted = b.OrderBy<T, T>(x => x);
                return aSorted.SequenceEqual(bSorted);
            });
    }
}