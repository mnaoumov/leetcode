namespace LeetCode.Problems._0002_Add_Two_Numbers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        var list1 = ListNode.Create(testCase.List1Values);
        var list2 = ListNode.Create(testCase.List2Values);
        var returnList = ListNode.Create(testCase.OutputValues);
        Assert.That(solution.AddTwoNumbers(list1, list2), Is.EqualTo(returnList));
    }

    public class TestCase : TestCaseBase
    {
        public int[] List1Values { get; [UsedImplicitly] init; } = null!;
        public int[] List2Values { get; [UsedImplicitly] init; } = null!;
        public int[] OutputValues { get; [UsedImplicitly] init; } = null!;
    }
}
