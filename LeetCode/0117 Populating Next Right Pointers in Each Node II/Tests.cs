using JetBrains.Annotations;

namespace LeetCode._0117_Populating_Next_Right_Pointers_in_Each_Node_II;

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

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] RootValues { get; [UsedImplicitly] init; } = null!;
        public int?[] OutputValues { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    RootValues = new int?[] { 1, 2, 3, 4, 5, null, 7 },
                    OutputValues = new int?[] { 1, null, 2, 3, null, 4, 5, 7, null },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    RootValues = Array.Empty<int?>(),
                    OutputValues = Array.Empty<int?>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    RootValues = new int?[] { 1, 2, 3, 4, null, null, 5 },
                    OutputValues = new int?[] { 1, null, 2, 3, null, 4, 5, null },
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    RootValues = new int?[] { 2, 1, 3, 0, 7, 9, 1, 2, null, 1, 0, null, null, 8, 8, null, null, null, null, 7 },
                    OutputValues = new int?[] { 2, null, 1, 3, null, 0, 7, 9, 1, null, 2, 1, 0, 8, 8, null, 7, null },
                    TestCaseName = nameof(Solution2)
                };
            }
        }
    }
}
