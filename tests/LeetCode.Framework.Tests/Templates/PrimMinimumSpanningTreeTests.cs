using static LeetCode.Templates.PrimMinimumSpanningTreeTemplate;

namespace LeetCode.Framework.Tests.Templates;

public class PrimMinimumSpanningTreeTests
{
    [Test]
    public void Weight_PicksCheapestEdges()
    {
        var graph = new EdgeWeightedGraph<int>();
        graph.AddEdge(1, 2, 5);
        graph.AddEdge(1, 3, 6);
        graph.AddEdge(2, 3, 1);

        var mst = new PrimMinimumSpanningTree<int>(graph);
        Assert.That(mst.Weight, Is.EqualTo(6));
        Assert.That(mst.Edges, Has.Count.EqualTo(2));
        Assert.That(mst.IsConnected, Is.True);
    }

    [Test]
    public void IsConnected_IsolatedNode_IsFalse()
    {
        // 1135 Connecting Cities: city 3 has no connection, so it never appears on an edge.
        var graph = new EdgeWeightedGraph<int>();

        for (var city = 1; city <= 3; city++)
        {
            graph.AddNode(city);
        }

        graph.AddEdge(1, 2, 4);

        var mst = new PrimMinimumSpanningTree<int>(graph);
        Assert.That(mst.IsConnected, Is.False);
    }

    [Test]
    public void EmptyGraph()
    {
        var mst = new PrimMinimumSpanningTree<int>(new EdgeWeightedGraph<int>());
        Assert.That(mst.Weight, Is.EqualTo(0));
        Assert.That(mst.IsConnected, Is.True);
    }

    [Test]
    public void SelfLoopsAndParallelEdges()
    {
        var graph = new EdgeWeightedGraph<string>();
        graph.AddEdge("a", "a", 0);
        graph.AddEdge("a", "b", 3);
        graph.AddEdge("a", "b", 2);

        var mst = new PrimMinimumSpanningTree<string>(graph);
        Assert.That(mst.Weight, Is.EqualTo(2));
    }

    [Test]
    public void Weight_MatchesKruskalOnRandomGraphs()
    {
        var random = new Random(7);

        for (var iteration = 0; iteration < 50; iteration++)
        {
            const int n = 12;
            var graph = new EdgeWeightedGraph<int>();
            var edges = new List<(int From, int To, int Weight)>();

            for (var node = 1; node < n; node++)
            {
                // A spanning path keeps the graph connected.
                edges.Add((node - 1, node, random.Next(1, 100)));
            }

            for (var i = 0; i < 30; i++)
            {
                edges.Add((random.Next(n), random.Next(n), random.Next(1, 100)));
            }

            foreach (var (from, to, weight) in edges)
            {
                graph.AddEdge(from, to, weight);
            }

            var roots = Enumerable.Range(0, n).ToArray();
            var expected = 0;

            foreach (var (from, to, weight) in edges.OrderBy(edge => edge.Weight))
            {
                var rootFrom = Find(from);
                var rootTo = Find(to);

                if (rootFrom == rootTo)
                {
                    continue;
                }

                roots[rootFrom] = rootTo;
                expected += weight;
            }

            var mst = new PrimMinimumSpanningTree<int>(graph);
            Assert.That(mst.Weight, Is.EqualTo(expected));
            Assert.That(mst.IsConnected, Is.True);
            continue;

            int Find(int node) => roots[node] == node ? node : roots[node] = Find(roots[node]);
        }
    }
}
