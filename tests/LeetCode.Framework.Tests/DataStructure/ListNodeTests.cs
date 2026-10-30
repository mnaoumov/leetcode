using LeetCode.DataStructure;

namespace LeetCode.Framework.Tests.DataStructure;

public class ListNodeTests
{
    private const int LargeSize = 100_000;

    private static readonly IEqualityComparer<ListNode?> Comparer = ListNode.StructuralComparer;

    private static ListNode CreateCyclic(int[] values, int cycleStart)
    {
        var head = ListNode.Create(values);
        var tail = head;
        while (tail.next != null)
        {
            tail = tail.next;
        }

        var start = head;
        for (var i = 0; i < cycleStart; i++)
        {
            start = start.next!;
        }

        tail.next = start;
        return head;
    }

    [Test]
    public void Create_SingleValue_ReturnsNode()
    {
        var node = ListNode.Create(1);
        Assert.That(node.val, Is.EqualTo(1));
        Assert.That(node.next, Is.Null);
    }

    [Test]
    public void Create_MultipleValues_BuildsList()
    {
        var node = ListNode.Create(1, 2, 3);
        Assert.That(node.val, Is.EqualTo(1));
        Assert.That(node.next!.val, Is.EqualTo(2));
        Assert.That(node.next.next!.val, Is.EqualTo(3));
        Assert.That(node.next.next.next, Is.Null);
    }

    [Test]
    public void Create_EmptyArray_Throws()
    {
        Assert.Throws<ArgumentException>(() => ListNode.Create());
    }

    [Test]
    public void CreateOrNull_Empty_ReturnsNull()
    {
        Assert.That(ListNode.CreateOrNull(), Is.Null);
    }

    [Test]
    public void CreateOrNull_WithValues_ReturnsList()
    {
        var node = ListNode.CreateOrNull(1, 2);
        Assert.That(node, Is.Not.Null);
        Assert.That(node!.val, Is.EqualTo(1));
        Assert.That(node.next!.val, Is.EqualTo(2));
    }

    [Test]
    public void Equals_IsByReference_AsOnLeetCode()
    {
        var a = ListNode.Create(1, 2, 3);
        var b = ListNode.Create(1, 2, 3);
        Assert.That(a.Equals(b), Is.False);
        Assert.That(a.Equals(a), Is.True);

        var parents = new Dictionary<ListNode, int> { [a] = 1, [b] = 2 };
        Assert.That(parents, Has.Count.EqualTo(2));
    }

    [Test]
    public void StructuralComparer_SameValues_ReturnsTrue()
    {
        var a = ListNode.Create(1, 2, 3);
        var b = ListNode.Create(1, 2, 3);
        Assert.That(a, Is.EqualTo(b).Using(Comparer));
    }

    [Test]
    public void StructuralComparer_DifferentValues_ReturnsFalse()
    {
        var a = ListNode.Create(1, 2, 3);
        var b = ListNode.Create(1, 2, 4);
        Assert.That(a, Is.Not.EqualTo(b).Using(Comparer));
    }

    [Test]
    public void StructuralComparer_DifferentLengths_ReturnsFalse()
    {
        var a = ListNode.Create(1, 2);
        var b = ListNode.Create(1, 2, 3);
        Assert.That(a, Is.Not.EqualTo(b).Using(Comparer));
    }

    [Test]
    public void StructuralComparer_Nulls()
    {
        Assert.That(Comparer.Equals(null, null), Is.True);
        Assert.That(Comparer.Equals(ListNode.Create(1), null), Is.False);
        Assert.That(Comparer.Equals(null, ListNode.Create(1)), Is.False);
    }

    [Test]
    public void StructuralComparer_SameValues_SameHash()
    {
        var a = ListNode.Create(1, 2);
        var b = ListNode.Create(1, 2);
        Assert.That(Comparer.GetHashCode(a), Is.EqualTo(Comparer.GetHashCode(b)));
    }

    [Test]
    public void StructuralComparer_LongLists_DoesNotOverflowTheStack()
    {
        var values = Enumerable.Range(0, LargeSize).ToArray();
        var a = ListNode.Create(values);
        var b = ListNode.Create(values);
        Assert.That(Comparer.Equals(a, b), Is.True);
        Assert.That(Comparer.GetHashCode(a), Is.EqualTo(Comparer.GetHashCode(b)));

        values[^1] = -1;
        Assert.That(Comparer.Equals(a, ListNode.Create(values)), Is.False);
    }

    [Test]
    public void StructuralComparer_CyclicLists_Terminates()
    {
        Assert.That(Comparer.Equals(CreateCyclic([1, 2, 3], 1), CreateCyclic([1, 2, 3], 1)), Is.True);
        Assert.That(Comparer.Equals(CreateCyclic([1, 2, 3], 1), CreateCyclic([1, 2, 3], 0)), Is.False);
        Assert.That(Comparer.Equals(CreateCyclic([1, 2, 3], 1), ListNode.Create(1, 2, 3)), Is.False);
    }

    [Test]
    public void StructuralComparer_CyclesOfDifferentLengthWithTheSameSequence_EqualWithTheSameHash()
    {
        // 1,1,1,... either way.
        var a = CreateCyclic([1], 0);
        var b = CreateCyclic([1, 1], 0);
        Assert.That(Comparer.Equals(a, b), Is.True);
        Assert.That(Comparer.GetHashCode(a), Is.EqualTo(Comparer.GetHashCode(b)));
    }

    [Test]
    public void StructuralComparer_WorksAsHashSetComparer()
    {
        var set = new HashSet<ListNode?>(Comparer) { ListNode.Create(1, 2, 3) };
        Assert.That(set.Contains(ListNode.Create(1, 2, 3)), Is.True);
        Assert.That(set.Contains(ListNode.Create(1, 2)), Is.False);
    }

    [Test]
    public void ToString_ReturnsSquareBracketFormat()
    {
        var node = ListNode.Create(1, 2, 3);
        Assert.That(node.ToString(), Is.EqualTo("[1,2,3]"));
    }

    [Test]
    public void ToString_LongList_DoesNotOverflowTheStack()
    {
        Assert.That(ListNode.Create(Enumerable.Range(0, LargeSize).ToArray()).ToString(), Does.StartWith("[0,1,2,"));
    }

    [Test]
    public void ToString_CyclicList_NamesTheCycle()
    {
        Assert.That(CreateCyclic([3, 2, 0, -4], 1).ToString(), Is.EqualTo("[3,2,0,-4,...cycle to index 1]"));
    }

    [Test]
    public void FindNode_ExistingValue_ReturnsNode()
    {
        var list = ListNode.Create(1, 2, 3);
        var found = list.FindNode(2);
        Assert.That(found, Is.Not.Null);
        Assert.That(found!.val, Is.EqualTo(2));
    }

    [Test]
    public void FindNode_FirstNode_ReturnsSelf()
    {
        var list = ListNode.Create(1, 2, 3);
        var found = list.FindNode(1);
        Assert.That(found, Is.SameAs(list));
    }

    [Test]
    public void FindNode_MissingValue_ReturnsNull()
    {
        var list = ListNode.Create(1, 2, 3);
        Assert.That(list.FindNode(99), Is.Null);
    }

    [Test]
    public void FindNode_LongList_DoesNotOverflowTheStack()
    {
        var list = ListNode.Create(Enumerable.Range(0, LargeSize).ToArray());
        Assert.That(list.FindNode(LargeSize - 1)!.val, Is.EqualTo(LargeSize - 1));
    }

    [Test]
    public void FindNode_CyclicListWithoutTheValue_ReturnsNull()
    {
        Assert.That(CreateCyclic([1, 2, 3], 0).FindNode(99), Is.Null);
    }

    [Test]
    public void FromObject_ConvertsObjectArray()
    {
        var result = ListNode.FromObject(new object[] { 1, 2, 3 });
        Assert.That(result, Is.EqualTo(ListNode.Create(1, 2, 3)).Using(Comparer));
    }

    [Test]
    public void FromObject_EmptyArray_ReturnsNull()
    {
        var result = ListNode.FromObject(Array.Empty<object>());
        Assert.That(result, Is.Null);
    }
}
