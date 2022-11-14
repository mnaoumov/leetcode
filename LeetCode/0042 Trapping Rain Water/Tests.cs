using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0042_Trapping_Rain_Water;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Trap(testCase.Height), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Height { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Height = new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 },
                    Output = 6,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Height = new[] { 4, 2, 0, 3, 2, 5 },
                    Output = 9,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Height = new[] { 4, 2, 3 },
                    Output = 1,
                    TestCaseName = nameof(Solution2)
                };
                yield return new TestCase
                {
                    Height = new[] { 6, 4, 2, 0, 3, 2, 0, 3, 1, 4, 5, 3, 2, 7, 5, 3, 0, 1, 2, 1, 3, 4, 6, 8, 1, 3 },
                    Output = 83,
                    TestCaseName = nameof(Solution3)
                };
            }
        }
    }
}