namespace LeetCode.Problems._1171_Remove_Zero_Sum_Consecutive_Nodes_from_Linked_List;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var head = ListNode.Create(testCase.Head);
        var ans = solution.RemoveZeroSumSublists(head);
        var sums = new HashSet<int> { 0 };

        var sum = 0;

        for (var node = ans; node != null; node = node.next)
        {
            sum += node.val;

            if (!sums.Add(sum))
            {
                Assert.Fail($"Repeating sum in result {ans}");
            }
        }

        var ansNode = ans;

        var skippedSum = 0;

        for (var originalNode = head; originalNode != null; originalNode = originalNode.next)
        {
            if (ansNode != null && originalNode.val == ansNode.val)
            {
                Assert.That(skippedSum, Is.Zero);
                ansNode = ansNode.next;
                skippedSum = 0;
            }
            else
            {
                skippedSum += originalNode.val;
            }
        }

        Assert.That(ansNode, Is.Null);
        Assert.That(skippedSum, Is.Zero);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Head { get; [UsedImplicitly] init; } = null!;
    }
}
