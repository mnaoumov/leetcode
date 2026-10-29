using static LeetCode.Templates.DijkstraDirectedShortestPathTemplate;

namespace LeetCode.Tests.Templates;

public class DijkstraDirectedShortestPathTests
{
    [Test]
    public void ShortestPath_DirectedGraph()
    {
        var graph = new DirectedEdgeWeightedGraph<string>();
        graph.AddEdge(new DirectedEdge<string>("A", "B", 1));
        graph.AddEdge(new DirectedEdge<string>("B", "C", 2));

        var sp = new DijkstraDirectedShortestPath<string>(graph, "A");
        Assert.That(sp.DistanceTo("C"), Is.EqualTo(3));
    }

    [Test]
    public void ShortestPath_NoReverseDirection()
    {
        var graph = new DirectedEdgeWeightedGraph<string>();
        graph.AddEdge(new DirectedEdge<string>("A", "B", 1));

        var sp = new DijkstraDirectedShortestPath<string>(graph, "B");
        Assert.That(sp.DistanceTo("A"), Is.EqualTo(double.PositiveInfinity));
    }

    [Test]
    public void ShortestPath_ChoosesShorterRoute()
    {
        var graph = new DirectedEdgeWeightedGraph<string>();
        graph.AddEdge(new DirectedEdge<string>("A", "B", 1));
        graph.AddEdge(new DirectedEdge<string>("B", "C", 1));
        graph.AddEdge(new DirectedEdge<string>("A", "C", 10));

        var sp = new DijkstraDirectedShortestPath<string>(graph, "A");
        Assert.That(sp.DistanceTo("C"), Is.EqualTo(2));
    }

    [Test]
    public void ShortestPath_DisconnectedNode_ReturnsInfinity()
    {
        var graph = new DirectedEdgeWeightedGraph<int>();
        graph.AddEdge(new DirectedEdge<int>(1, 2, 5));
        graph.AddNode(3);

        var sp = new DijkstraDirectedShortestPath<int>(graph, 1);
        Assert.That(sp.DistanceTo(3), Is.EqualTo(double.PositiveInfinity));
    }
}
