namespace LeetCode.Problems._1669_Merge_In_Between_Linked_Lists;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(
            solution.MergeInBetween(ListNode.Create(testCase.List1), testCase.A, testCase.B,
                ListNode.Create(testCase.List2)), Is.EqualTo(ListNode.CreateOrNull(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int[] List1 { get; [UsedImplicitly] init; } = null!;
        public int A { get; [UsedImplicitly] init; }
        public int B { get; [UsedImplicitly] init; }
        public int[] List2 { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
