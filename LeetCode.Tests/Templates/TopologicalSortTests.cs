using static LeetCode.Templates.TopologicalSortTemplate;

namespace LeetCode.Tests.Templates;

public class TopologicalSortTests
{
    [Test]
    public void SimpleDAG_ReturnsValidOrder()
    {
        // A → B → C
        var graph = new DirectedGraph<string>();
        graph.AddEdge("A", "B");
        graph.AddEdge("B", "C");

        var topo = new TopologicalSort<string>(graph);
        Assert.That(topo.IsAcyclic, Is.True);

        var order = topo.Order.ToList();
        Assert.That(order.IndexOf("A"), Is.LessThan(order.IndexOf("B")));
        Assert.That(order.IndexOf("B"), Is.LessThan(order.IndexOf("C")));
    }

    [Test]
    public void DiamondDAG_ReturnsValidOrder()
    {
        // A → B → D
        // A → C → D
        var graph = new DirectedGraph<string>();
        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");
        graph.AddEdge("B", "D");
        graph.AddEdge("C", "D");

        var topo = new TopologicalSort<string>(graph);
        Assert.That(topo.IsAcyclic, Is.True);

        var order = topo.Order.ToList();
        Assert.That(order.IndexOf("A"), Is.LessThan(order.IndexOf("B")));
        Assert.That(order.IndexOf("A"), Is.LessThan(order.IndexOf("C")));
        Assert.That(order.IndexOf("B"), Is.LessThan(order.IndexOf("D")));
        Assert.That(order.IndexOf("C"), Is.LessThan(order.IndexOf("D")));
    }

    [Test]
    public void CyclicGraph_DetectsCycle()
    {
        // A → B → C → A
        var graph = new DirectedGraph<string>();
        graph.AddEdge("A", "B");
        graph.AddEdge("B", "C");
        graph.AddEdge("C", "A");

        var topo = new TopologicalSort<string>(graph);
        Assert.That(topo.IsAcyclic, Is.False);
        Assert.That(topo.Order, Is.Empty);
    }

    [Test]
    public void SingleNode_IsAcyclic()
    {
        var graph = new DirectedGraph<int>();
        graph.AddNode(1);

        var topo = new TopologicalSort<int>(graph);
        Assert.That(topo.IsAcyclic, Is.True);
        Assert.That(topo.Order, Is.EqualTo(new[] { 1 }));
    }

    [Test]
    public void DisconnectedNodes_AllIncluded()
    {
        var graph = new DirectedGraph<int>();
        graph.AddNode(1);
        graph.AddNode(2);
        graph.AddNode(3);

        var topo = new TopologicalSort<int>(graph);
        Assert.That(topo.IsAcyclic, Is.True);
        Assert.That(topo.Order.OrderBy(x => x), Is.EqualTo(new[] { 1, 2, 3 }));
    }

    [Test]
    public void SelfLoop_DetectsCycle()
    {
        var graph = new DirectedGraph<int>();
        graph.AddEdge(1, 1);

        var topo = new TopologicalSort<int>(graph);
        Assert.That(topo.IsAcyclic, Is.False);
    }
}
