using LeetCode.DataStructure;

namespace LeetCode.Framework.Tests.DataStructure;

public class TreeNodeTests
{
    private const int LargeSize = 100_000;

    private static readonly IEqualityComparer<TreeNode?> Comparer = TreeNode.StructuralComparer;

    private static TreeNode CreateSkewed(int size)
    {
        var root = new TreeNode(size - 1);
        for (var i = size - 2; i >= 0; i--)
        {
            root = new TreeNode(i, right: root);
        }

        return root;
    }

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
    public void StructuralComparer_SameStructure_ReturnsTrue()
    {
        var a = TreeNode.Create([1, 2, 3]);
        var b = TreeNode.Create([1, 2, 3]);
        Assert.That(a, Is.EqualTo(b).Using(Comparer));
    }

    [Test]
    public void StructuralComparer_DifferentStructure_ReturnsFalse()
    {
        var a = TreeNode.Create([1, 2, 3]);
        var b = TreeNode.Create([1, 2, 4]);
        Assert.That(a, Is.Not.EqualTo(b).Using(Comparer));
    }

    [Test]
    public void StructuralComparer_Null_ReturnsFalse()
    {
        var a = TreeNode.Create([1]);
        Assert.That(Comparer.Equals(a, null), Is.False);
    }

    [Test]
    public void Equals_IsByReference_AsOnLeetCode()
    {
        var a = TreeNode.Create([1, 2, 3]);
        var b = TreeNode.Create([1, 2, 3]);
        Assert.That(a.Equals(b), Is.False);
        Assert.That(a.Equals(a), Is.True);

        // 0988 Solution3 keys a parent map by node, and two leaves with the same value must stay apart.
        var parents = new Dictionary<TreeNode, TreeNode> { [a.left!] = a, [b.left!] = b };
        Assert.That(parents, Has.Count.EqualTo(2));
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
    public void StructuralComparer_SkewedTrees_DoesNotOverflowTheStack()
    {
        Assert.That(Comparer.Equals(CreateSkewed(LargeSize), CreateSkewed(LargeSize)), Is.True);

        var different = CreateSkewed(LargeSize);
        var leaf = different;
        while (leaf.right != null)
        {
            leaf = leaf.right;
        }

        leaf.val = -1;
        Assert.That(Comparer.Equals(CreateSkewed(LargeSize), different), Is.False);
    }

    [Test]
    public void StructuralComparer_SkewedTrees_SameHash()
    {
        var a = CreateSkewed(LargeSize);
        var b = CreateSkewed(LargeSize);
        Assert.That(Comparer.GetHashCode(a), Is.EqualTo(Comparer.GetHashCode(b)));
    }

    [Test]
    public void ToString_SkewedTree_DoesNotOverflowTheStack()
    {
        Assert.That(CreateSkewed(LargeSize).ToString(), Does.StartWith("0,null,1,null,2"));
    }

    [Test]
    public void StructuralComparer_EqualTrees_SameHash()
    {
        var a = TreeNode.Create([1, null, 2, 3]);
        var b = TreeNode.Create([1, null, 2, 3]);
        Assert.That(Comparer.GetHashCode(a), Is.EqualTo(Comparer.GetHashCode(b)));
    }

    [Test]
    public void StructuralComparer_WorksAsHashSetComparerAndInEquivalence()
    {
        var set = new HashSet<TreeNode?>(Comparer) { TreeNode.Create([1, 2, 3]) };
        Assert.That(set.Contains(TreeNode.Create([1, 2, 3])), Is.True);
        Assert.That(set.Contains(TreeNode.Create([1, 2])), Is.False);

        Assert.That(new[] { TreeNode.Create([1]), TreeNode.Create([2]) },
            Is.EquivalentTo(new[] { TreeNode.Create([2]), TreeNode.Create([1]) }).Using(Comparer));
    }

    [Test]
    public void SharedSubtree_IsNotACycle()
    {
        var shared = TreeNode.Create([0]);
        var tree = new TreeNode(1, shared, shared);
        Assert.That(tree.ToString(), Is.EqualTo("1,0,0"));
        Assert.That(tree, Is.EqualTo(TreeNode.Create([1, 0, 0])).Using(Comparer));
    }

    [Test]
    public void CyclicTree_StructuralComparerTerminatesAndToStringNamesTheCycle()
    {
        var a = TreeNode.Create([1, 2]);
        a.left!.left = a;
        var b = TreeNode.Create([1, 2]);
        b.left!.left = b;

        Assert.That(Comparer.Equals(a, b), Is.True);
        Assert.That(Comparer.Equals(a, TreeNode.Create([1, 2])), Is.False);
        Assert.That(Comparer.GetHashCode(a), Is.EqualTo(Comparer.GetHashCode(b)));
        Assert.That(a.ToString(), Is.EqualTo("1,...cycle"));
        Assert.Throws<InvalidOperationException>(() => TreeNode.GetValues(a));
        Assert.That(a.FindNode(3), Is.Null);
    }

    [Test]
    public void FromObject_EmptyArray_ReturnsNull()
    {
        var result = TreeNode.FromObject(Array.Empty<object?>());
        Assert.That(result, Is.Null);
    }
}
