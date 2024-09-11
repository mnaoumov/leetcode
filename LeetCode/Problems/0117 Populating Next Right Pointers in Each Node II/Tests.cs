namespace LeetCode.Problems._0117_Populating_Next_Right_Pointers_in_Each_Node_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var output = solution.Connect(Node.Create(testCase.RootValues));
        var queue = new Queue<Node?>();
        queue.Enqueue(output);

        var actualValues = new List<int?>();

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (node == null)
            {
                continue;
            }

            actualValues.Add(node.val);

            if (node.next == null)
            {
                actualValues.Add(null);
            }

            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }

        AssertCollectionEqualWithDetails(actualValues, testCase.OutputValues);
    }

    public class TestCase : TestCaseBase
    {
        public int?[] RootValues { get; [UsedImplicitly] init; } = null!;
        public int?[] OutputValues { get; [UsedImplicitly] init; } = null!;
    }
}
