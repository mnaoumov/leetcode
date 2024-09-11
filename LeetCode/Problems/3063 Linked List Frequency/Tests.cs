namespace LeetCode.Problems._3063_Linked_List_Frequency;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var ans = solution.FrequenciesOfElements(ListNode.Create(testCase.Head));
        AssertCollectionEquivalentWithDetails(GetValues(ans), testCase.Output);
    }

    private static IEnumerable<int> GetValues(ListNode head)
    {
        for (var node = head; node != null; node = node.next)
        {
            yield return node.val;
        }
    }

    public class TestCase : TestCaseBase
    {
        public int[] Head { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
