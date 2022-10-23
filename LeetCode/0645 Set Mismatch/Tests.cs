using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0645_Set_Mismatch;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindErrorNums(testCase.Nums), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int[] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 1, 2, 2, 4 },
                    Output = new[] { 2, 3 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 1 },
                    Output = new[] { 1, 2 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}