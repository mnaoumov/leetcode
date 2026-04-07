using LeetCode.DataStructure;

namespace LeetCode.Tests.DataStructure;

public class NodeTests
{
    [Test]
    public void CreateOrNull_EmptyArray_ReturnsNull()
    {
        Assert.That(Node.CreateOrNull([]), Is.Null);
    }

    [Test]
    public void CreateOrNull_SingleNode_ReturnsLeaf()
    {
        var node = Node.CreateOrNull([1, null]);
        Assert.That(node, Is.Not.Null);
        Assert.That(node!.val, Is.EqualTo(1));
        Assert.That(node.children, Is.Empty);
    }

    [Test]
    public void CreateOrNull_TwoLevels_BuildsCorrectStructure()
    {
        // [1, null, 3, 2, 4, null, 5, 6]
        // Root=1, children=[3,2,4], 3's children=[5,6]
        var node = Node.CreateOrNull([1, null, 3, 2, 4, null, 5, 6]);

        Assert.That(node!.val, Is.EqualTo(1));
        Assert.That(node.children.Count, Is.EqualTo(3));
        Assert.That(node.children[0].val, Is.EqualTo(3));
        Assert.That(node.children[1].val, Is.EqualTo(2));
        Assert.That(node.children[2].val, Is.EqualTo(4));
        Assert.That(node.children[0].children.Count, Is.EqualTo(2));
        Assert.That(node.children[0].children[0].val, Is.EqualTo(5));
        Assert.That(node.children[0].children[1].val, Is.EqualTo(6));
        Assert.That(node.children[1].children, Is.Empty);
        Assert.That(node.children[2].children, Is.Empty);
    }

    [Test]
    public void ToString_ReturnsValueInBraces()
    {
        var node = new Node(42);
        Assert.That(node.ToString(), Is.EqualTo("{42}"));
    }
}
