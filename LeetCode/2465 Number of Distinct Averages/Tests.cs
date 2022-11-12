using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2465_Number_of_Distinct_Averages;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.DistinctAverages(testCase.Nums), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 4, 1, 4, 0, 3, 5 },
                    Output = 2,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 100 },
                    Output = 1,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
