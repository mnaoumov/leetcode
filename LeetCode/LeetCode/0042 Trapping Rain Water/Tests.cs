using NUnit.Framework;

namespace LeetCode._0042_Trapping_Rain_Water;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Trap(testCase.Height), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Height { get; private init; } = null!;
        public int Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Height = new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 },
                    Return = 6,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Height = new[] { 4, 2, 0, 3, 2, 5 },
                    Return = 9,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Height = new[] { 4, 2, 3 },
                    Return = 1
                };
            }
        }
    }
}