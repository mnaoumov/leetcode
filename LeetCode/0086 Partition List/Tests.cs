using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0086_Partition_List;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Partition(ListNode.Create(testCase.Values), testCase.X), Is.EqualTo(ListNode.Create(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Values { get; [UsedImplicitly] init; } = null!;
        public int X { get; [UsedImplicitly] init; }
        public int[] OutputValues { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Values = new[] { 1, 4, 3, 2, 5, 2 },
                    X = 3,
                    OutputValues = new[] { 1, 2, 2, 4, 3, 5 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = new[] { 2, 1 },
                    X = 2,
                    OutputValues = new[] { 1, 2 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Values = new[] { 1, 4, 3, 0, 2, 5, 2 },
                    X = 3,
                    OutputValues = new[] { 1, 0, 2, 2, 4, 3, 5 },
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}