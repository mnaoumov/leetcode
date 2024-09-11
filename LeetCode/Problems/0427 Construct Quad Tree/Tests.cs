using Newtonsoft.Json;

namespace LeetCode.Problems._0427_Construct_Quad_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var node = solution.Construct(testCase.Grid);
        var actualOutput = Serialize(node);
        var expectedOutput = testCase.Output;

        var detailedMessage =
            $"\r\nActual:\r\n{JsonConvert.SerializeObject(actualOutput)}\r\n\r\nExpected:\r\n{JsonConvert.SerializeObject(expectedOutput)}\r\n\r\n";

        Assert.That(actualOutput.Length, Is.EqualTo(expectedOutput.Length),
            $"Length don't match. Actual Length: {actualOutput.Length}, Expected Length: {expectedOutput.Length}{detailedMessage}");

        for (var i = 0; i < actualOutput.Length; i++)
        {
            var actualOutputItem = actualOutput[i];
            var expectedOutputItem = expectedOutput[i];
            var areEqual = actualOutputItem != null && expectedOutputItem != null && actualOutputItem.SequenceEqual(expectedOutputItem) ||
                           actualOutputItem is null && expectedOutputItem is null;

            if (areEqual)
            {
                continue;
            }

            if (actualOutputItem != null && expectedOutputItem != null)
            {
                if (actualOutputItem.Length != 2)
                {
                    Assert.Fail($"{i}'s output {JsonConvert.SerializeObject(actualOutputItem)} length is not equal to 2{detailedMessage}");
                }

                if (actualOutputItem[0] == 0 && expectedOutputItem[0] == 0)
                {
                    continue;
                }
            }

            Assert.Fail($"{i}'s output {JsonConvert.SerializeObject(actualOutputItem)} is not equal to {JsonConvert.SerializeObject(expectedOutputItem)}{detailedMessage}");
        }
    }

    private static int[]?[] Serialize(Node node)
    {
        var list = new List<int[]?>();

        var queue = new Queue<Node?>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            var count = queue.Count;
            var previousNullCounts = 0;

            for (var i = 0; i < count; i++)
            {
                var node2 = queue.Dequeue();
                if (node2 == null)
                {
                    list.Add(null);
                    continue;
                }

                if (node2.isLeaf)
                {
                    list.Add(new[] { 1, node2.val ? 1 : 0 });
                    previousNullCounts += 4;
                }
                else
                {
                    list.Add(new[] { 0, node2.val ? 1 : 0 });

                    for (var j = 0; j < previousNullCounts; j++)
                    {
                        queue.Enqueue(null);
                    }

                    queue.Enqueue(node2.topLeft!);
                    queue.Enqueue(node2.topRight!);
                    queue.Enqueue(node2.bottomLeft!);
                    queue.Enqueue(node2.bottomRight!);
                    previousNullCounts = 0;
                }
            }
        }

        return list.ToArray();
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Grid { get; [UsedImplicitly] init; } = null!;
        public int[]?[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
