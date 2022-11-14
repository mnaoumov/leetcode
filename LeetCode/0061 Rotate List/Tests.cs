using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0061_Rotate_List;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.RotateRight(ListNode.Create(testCase.Values), testCase.K), Is.EqualTo(ListNode.Create(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Values { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int[] OutputValues { get; [UsedImplicitly] init; } = null!;


        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Values = new[] { 1, 2, 3, 4, 5 },
                    K = 2,
                    OutputValues = new[] { 4, 5, 1, 2, 3 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = new[] { 0, 1, 2 },
                    K = 4,
                    OutputValues = new[] { 2, 0, 1 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}