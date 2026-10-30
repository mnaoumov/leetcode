namespace LeetCode.Problems._2699_Modify_Graph_Edge_Weights;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        // Any modification is accepted: each -1 weight set within the limits, the others kept, and the target distance met.
        const int unset = -1;
        const int maxWeight = 2_000_000_000;
        var originalWeights = testCase.Edges.ToDictionary(edge => GetKey(edge[0], edge[1]), edge => edge[2]);

        var answer = solution.ModifiedGraphEdges(testCase.N, testCase.Edges.Select(edge => edge.ToArray()).ToArray(),
            testCase.Source, testCase.Destination, testCase.Target);

        if (testCase.Output.Length == 0)
        {
            Assert.That(answer, Is.Empty);
            return;
        }

        Assert.That(answer.Select(edge => GetKey(edge[0], edge[1])), Is.EquivalentTo(originalWeights.Keys));

        foreach (var edge in answer)
        {
            var originalWeight = originalWeights[GetKey(edge[0], edge[1])];
            Assert.That(edge[2], Is.InRange(originalWeight == unset ? 1 : originalWeight,
                originalWeight == unset ? maxWeight : originalWeight));
        }

        Assert.That(GetDistance(testCase.N, answer, testCase.Source, testCase.Destination), Is.EqualTo(testCase.Target));
    }

    private static (int, int) GetKey(int u, int v) => (Math.Min(u, v), Math.Max(u, v));

    private static long GetDistance(int n, int[][] edges, int source, int destination)
    {
        var weights = new long?[n, n];

        foreach (var edge in edges)
        {
            weights[edge[0], edge[1]] = edge[2];
            weights[edge[1], edge[0]] = edge[2];
        }

        var distances = Enumerable.Repeat(long.MaxValue, n).ToArray();
        var visited = new bool[n];
        distances[source] = 0;

        for (var step = 0; step < n; step++)
        {
            var u = Enumerable.Range(0, n).Where(node => !visited[node]).MinBy(node => distances[node]);

            if (distances[u] == long.MaxValue)
            {
                break;
            }

            visited[u] = true;

            for (var v = 0; v < n; v++)
            {
                if (weights[u, v] is { } weight)
                {
                    distances[v] = Math.Min(distances[v], distances[u] + weight);
                }
            }
        }

        return distances[destination];
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public int Source { get; [UsedImplicitly] init; }
        public int Destination { get; [UsedImplicitly] init; }
        public int Target { get; [UsedImplicitly] init; }
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
