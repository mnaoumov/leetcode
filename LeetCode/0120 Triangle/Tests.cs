using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0120_Triangle;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumTotal(testCase.Triangle), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public IList<IList<int>> Triangle { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Triangle = new IList<int>[]
                    {
                        new[] { 2 }, new[] { 3, 4 }, new[] { 6, 5, 7 }, new[] { 4, 1, 8, 3 }
                    },
                    Output = 11,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Triangle = new IList<int>[]
                    {
                        new[] { -10 }
                    },
                    Output = -10,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
