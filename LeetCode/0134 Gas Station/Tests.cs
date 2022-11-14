using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0134_Gas_Station;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CanCompleteCircuit(testCase.Gas, testCase.Cost), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Gas { get; [UsedImplicitly] init; } = null!;
        public int[] Cost { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Gas = new[] { 1, 2, 3, 4, 5 },
                    Cost = new[] { 3, 4, 5, 1, 2 },
                    Output = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Gas = new[] { 2, 3, 4 },
                    Cost = new[] { 3, 4, 3 },
                    Output = -1,
                    TestCaseName = "Example 2"
                };


                yield return new TestCase
                {
                    Gas = new[] { 3, 1, 1 },
                    Cost = new[] { 1, 2, 2 },
                    Output = 0,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}
