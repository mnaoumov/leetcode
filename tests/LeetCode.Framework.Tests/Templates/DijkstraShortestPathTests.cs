using static LeetCode.Templates.DijkstraShortestPathTemplate;

namespace LeetCode.Tests.Templates;

public class DijkstraShortestPathTests
{
    [Test]
    public void ShortestPath_SimpleGraph()
    {
        var graph = new EdgeWeightedGraph<string>();
        graph.AddEdge(new Edge<string>("A", "B", 1));
        graph.AddEdge(new Edge<string>("B", "C", 2));

        var sp = new DijkstraShortestPath<string>(graph, "A");
        Assert.That(sp.DistanceTo("A"), Is.EqualTo(0));
        Assert.That(sp.DistanceTo("B"), Is.EqualTo(1));
        Assert.That(sp.DistanceTo("C"), Is.EqualTo(3));
    }

    [Test]
    public void ShortestPath_ChoosesShorterRoute()
    {
        var graph = new EdgeWeightedGraph<string>();
        graph.AddEdge(new Edge<string>("A", "B", 1));
        graph.AddEdge(new Edge<string>("B", "C", 1));
        graph.AddEdge(new Edge<string>("A", "C", 10));

        var sp = new DijkstraShortestPath<string>(graph, "A");
        Assert.That(sp.DistanceTo("C"), Is.EqualTo(2));
    }

    [Test]
    public void ShortestPath_DisconnectedNode_ReturnsInfinity()
    {
        var graph = new EdgeWeightedGraph<int>();
        graph.AddEdge(new Edge<int>(1, 2, 5));
        graph.AddNode(3);

        var sp = new DijkstraShortestPath<int>(graph, 1);
        Assert.That(sp.DistanceTo(3), Is.EqualTo(double.PositiveInfinity));
    }

    [Test]
    public void ShortestPath_UnknownNode_ReturnsInfinity()
    {
        var graph = new EdgeWeightedGraph<int>();
        graph.AddEdge(new Edge<int>(1, 2, 5));

        var sp = new DijkstraShortestPath<int>(graph, 1);
        Assert.That(sp.DistanceTo(99), Is.EqualTo(double.PositiveInfinity));
    }

    [Test]
    public void Edge_Other_ReturnsOppositeNode()
    {
        var edge = new Edge<string>("A", "B", 1);
        Assert.That(edge.Other("A"), Is.EqualTo("B"));
        Assert.That(edge.Other("B"), Is.EqualTo("A"));
    }

    [Test]
    public void Edge_Other_InvalidNode_Throws()
    {
        var edge = new Edge<string>("A", "B", 1);
        Assert.Throws<InvalidOperationException>(() => edge.Other("C"));
    }
}
