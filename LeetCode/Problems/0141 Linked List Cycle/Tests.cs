namespace LeetCode.Problems._0141_Linked_List_Cycle;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var head = ListNode.Create(testCase.HeadValues);

        if (testCase.Pos >= 0)
        {
            var posNode = head;

            for (var i = 0; i < testCase.Pos; i++)
            {
                posNode = posNode.next!;
            }

            var tail = posNode;

            while (tail.next != null)
            {
                tail = tail.next;
            }

            tail.next = posNode;
        }

        Assert.That(solution.HasCycle(head), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] HeadValues { get; [UsedImplicitly] init; } = null!;
        public int Pos { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }
    }
}
