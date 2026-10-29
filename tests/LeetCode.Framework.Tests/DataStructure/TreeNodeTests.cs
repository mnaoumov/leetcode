using LeetCode.DataStructure;

namespace LeetCode.Tests.DataStructure;

public class TreeNodeTests
{
    [Test]
    public void CreateOrNull_EmptyArray_ReturnsNull()
    {
        Assert.That(TreeNode.CreateOrNull([]), Is.Null);
    }

    [Test]
    public void CreateOrNull_SingleNode_ReturnsLeaf()
    {
        var node = TreeNode.CreateOrNull([1]);

        Assert.That(node, Is.Not.Null);
        Assert.That(node!.val, Is.EqualTo(1));
        Assert.That(node.left, Is.Null);
        Assert.That(node.right, Is.Null);
    }

    [Test]
    public void CreateOrNull_FullTree_BuildsCorrectStructure()
    {
        var node = TreeNode.CreateOrNull([1, 2, 3]);

        Assert.That(node!.val, Is.EqualTo(1));
        Assert.That(node.left!.val, Is.EqualTo(2));
        Assert.That(node.right!.val, Is.EqualTo(3));
    }

    [Test]
    public void CreateOrNull_SparseTree_HandlesNulls()
    {
        var node = TreeNode.CreateOrNull([1, null, 2, 3]);

        Assert.That(node!.val, Is.EqualTo(1));
        Assert.That(node.left, Is.Null);
        Assert.That(node.right!.val, Is.EqualTo(2));
        Assert.That(node.right.left!.val, Is.EqualTo(3));
        Assert.That(node.right.right, Is.Null);
    }

    [Test]
    public void Create_EmptyArray_Throws()
    {
        Assert.Throws<ArgumentException>(() => TreeNode.Create([]));
    }

    [Test]
    public void Create_ValidArray_ReturnsTree()
    {
        var node = TreeNode.Create([1, 2, 3]);
        Assert.That(node.val, Is.EqualTo(1));
    }

    [Test]
    public void GetValues_Roundtrip()
    {
        int?[] values = [1, null, 2, 3];
        var node = TreeNode.CreateOrNull(values);
        var result = TreeNode.GetValues(node);
        Assert.That(result, Is.EqualTo(values));
    }

    [Test]
    public void GetValues_NullTree_ReturnsEmpty()
    {
        Assert.That(TreeNode.GetValues(null), Is.Empty);
    }

    [Test]
    public void GetValues_TrimsTrailingNulls()
    {
        var node = TreeNode.CreateOrNull([1, 2]);
        var result = TreeNode.GetValues(node);
        Assert.That(result, Is.EqualTo(new int?[] { 1, 2 }));
    }

    [Test]
    public void Equals_SameStructure_ReturnsTrue()
    {
        var a = TreeNode.Create([1, 2, 3]);
        var b = TreeNode.Create([1, 2, 3]);
        Assert.That(a, Is.EqualTo(b));
    }

    [Test]
    public void Equals_DifferentStructure_ReturnsFalse()
    {
        var a = TreeNode.Create([1, 2, 3]);
        var b = TreeNode.Create([1, 2, 4]);
        Assert.That(a, Is.Not.EqualTo(b));
    }

    [Test]
    public void Equals_Null_ReturnsFalse()
    {
        var a = TreeNode.Create([1]);
        Assert.That(a.Equals(null), Is.False);
    }

    [Test]
    public void ToString_ReturnsCommaSeparated()
    {
        var node = TreeNode.Create([1, null, 2, 3]);
        Assert.That(node.ToString(), Is.EqualTo("1,null,2,3"));
    }

    [Test]
    public void FindNode_ExistingValue_ReturnsNode()
    {
        var tree = TreeNode.Create([1, 2, 3, 4, 5]);
        var found = tree.FindNode(5);
        Assert.That(found, Is.Not.Null);
        Assert.That(found!.val, Is.EqualTo(5));
    }

    [Test]
    public void FindNode_MissingValue_ReturnsNull()
    {
        var tree = TreeNode.Create([1, 2, 3]);
        Assert.That(tree.FindNode(99), Is.Null);
    }

    [Test]
    public void FromObject_ConvertsObjectArray()
    {
        var result = TreeNode.FromObject(new object?[] { 1, null, 2 });
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.val, Is.EqualTo(1));
        Assert.That(result.left, Is.Null);
        Assert.That(result.right!.val, Is.EqualTo(2));
    }

    [Test]
    public void FromObject_EmptyArray_ReturnsNull()
    {
        var result = TreeNode.FromObject(Array.Empty<object?>());
        Assert.That(result, Is.Null);
    }
}
