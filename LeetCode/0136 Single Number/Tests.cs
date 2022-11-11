using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0136_Single_Number;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SingleNumber(testCase.Nums), Is.EqualTo(testCase.Output));
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
                    Nums = new[] { 2, 2, 1 },
                    Output = 1,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 4, 1, 2, 1, 2 },
                    Output = 4,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1 },
                    Output = 1,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
