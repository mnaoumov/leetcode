using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._0445_Add_Two_Numbers_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.AddTwoNumbers(ListNode.Create(testCase.L1), ListNode.Create(testCase.L2)),
            Is.EqualTo(ListNode.Create(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int[] L1 { get; [UsedImplicitly] init; } = null!;
        public int[] L2 { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
