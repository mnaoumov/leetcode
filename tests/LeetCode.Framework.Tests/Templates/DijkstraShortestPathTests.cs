using static LeetCode.Templates.DijkstraShortestPathTemplate;

namespace LeetCode.Framework.Tests.Templates;

public class DijkstraShortestPathTests
{
    [Test]
    public void ShortestPath_SimpleGraph()
    {
        var graph = new EdgeWeightedGraph<string>();
        graph.AddUndirectedEdge("A", "B", 1);
        graph.AddUndirectedEdge("B", "C", 2);

        var sp = new DijkstraShortestPath<string>(graph, "A");
        Assert.That(sp.DistanceTo("A"), Is.EqualTo(0));
        Assert.That(sp.DistanceTo("B"), Is.EqualTo(1));
        Assert.That(sp.DistanceTo("C"), Is.EqualTo(3));
    }

    [Test]
    public void ShortestPath_ChoosesShorterRoute()
    {
        var graph = new EdgeWeightedGraph<string>();
        graph.AddUndirectedEdge("A", "B", 1);
        graph.AddUndirectedEdge("B", "C", 1);
        graph.AddUndirectedEdge("A", "C", 10);

        var sp = new DijkstraShortestPath<string>(graph, "A");
        Assert.That(sp.DistanceTo("C"), Is.EqualTo(2));
    }

    [Test]
    public void ShortestPath_UndirectedEdge_WorksBothWays()
    {
        var graph = new EdgeWeightedGraph<string>();
        graph.AddUndirectedEdge("A", "B", 4);

        var sp = new DijkstraShortestPath<string>(graph, "B");
        Assert.That(sp.DistanceTo("A"), Is.EqualTo(4));
    }

    [Test]
    public void ShortestPath_DisconnectedNode_ReturnsInfinity()
    {
        var graph = new EdgeWeightedGraph<int>();
        graph.AddUndirectedEdge(1, 2, 5);
        graph.AddNode(3);

        var sp = new DijkstraShortestPath<int>(graph, 1);
        Assert.That(sp.DistanceTo(3), Is.EqualTo(double.PositiveInfinity));
    }

    [Test]
    public void ShortestPath_UnknownNode_ReturnsInfinity()
    {
        var graph = new EdgeWeightedGraph<int>();
        graph.AddUndirectedEdge(1, 2, 5);

        var sp = new DijkstraShortestPath<int>(graph, 1);
        Assert.That(sp.DistanceTo(99), Is.EqualTo(double.PositiveInfinity));
    }

    [Test]
    public void ShortestPath_DirectedGraph()
    {
        var graph = new EdgeWeightedGraph<string>();
        graph.AddEdge(new Edge<string>("A", "B", 1));
        graph.AddEdge(new Edge<string>("B", "C", 2));

        var sp = new DijkstraShortestPath<string>(graph, "A");
        Assert.That(sp.DistanceTo("C"), Is.EqualTo(3));
    }

    [Test]
    public void ShortestPath_DirectedEdge_NoReverseDirection()
    {
        var graph = new EdgeWeightedGraph<string>();
        graph.AddEdge(new Edge<string>("A", "B", 1));

        var sp = new DijkstraShortestPath<string>(graph, "B");
        Assert.That(sp.DistanceTo("A"), Is.EqualTo(double.PositiveInfinity));
    }

    [Test]
    public void ShortestPath_DirectedGraph_ChoosesShorterRoute()
    {
        var graph = new EdgeWeightedGraph<string>();
        graph.AddEdge(new Edge<string>("A", "B", 1));
        graph.AddEdge(new Edge<string>("B", "C", 1));
        graph.AddEdge(new Edge<string>("A", "C", 10));

        var sp = new DijkstraShortestPath<string>(graph, "A");
        Assert.That(sp.DistanceTo("C"), Is.EqualTo(2));
    }

    [Test]
    public void ShortestPath_StaleQueueEntries_StillCorrect()
    {
        // C is queued at 10, then at 3, then at 2; the stale entries must be skipped.
        var graph = new EdgeWeightedGraph<string>();
        graph.AddEdge(new Edge<string>("A", "C", 10));
        graph.AddEdge(new Edge<string>("A", "B", 1));
        graph.AddEdge(new Edge<string>("B", "C", 2));
        graph.AddEdge(new Edge<string>("A", "D", 1));
        graph.AddEdge(new Edge<string>("D", "C", 1));
        graph.AddEdge(new Edge<string>("C", "E", 1));

        var sp = new DijkstraShortestPath<string>(graph, "A");
        Assert.That(sp.DistanceTo("C"), Is.EqualTo(2));
        Assert.That(sp.DistanceTo("E"), Is.EqualTo(3));
    }
}
