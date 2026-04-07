using LeetCode.DataStructure;

namespace LeetCode.Tests.DataStructure;

public class ListNodeTests
{
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
    public void Equals_SameValues_ReturnsTrue()
    {
        var a = ListNode.Create(1, 2, 3);
        var b = ListNode.Create(1, 2, 3);
        Assert.That(a, Is.EqualTo(b));
    }

    [Test]
    public void Equals_DifferentValues_ReturnsFalse()
    {
        var a = ListNode.Create(1, 2, 3);
        var b = ListNode.Create(1, 2, 4);
        Assert.That(a, Is.Not.EqualTo(b));
    }

    [Test]
    public void Equals_DifferentLengths_ReturnsFalse()
    {
        var a = ListNode.Create(1, 2);
        var b = ListNode.Create(1, 2, 3);
        Assert.That(a, Is.Not.EqualTo(b));
    }

    [Test]
    public void ToString_ReturnsSquareBracketFormat()
    {
        var node = ListNode.Create(1, 2, 3);
        Assert.That(node.ToString(), Is.EqualTo("[1,2,3]"));
    }

    [Test]
    public void GetHashCode_SameValues_SameHash()
    {
        var a = ListNode.Create(1, 2);
        var b = ListNode.Create(1, 2);
        Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
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
    public void FromObject_ConvertsObjectArray()
    {
        var result = ListNode.FromObject(new object[] { 1, 2, 3 });
        Assert.That(result, Is.EqualTo(ListNode.Create(1, 2, 3)));
    }

    [Test]
    public void FromObject_EmptyArray_ReturnsNull()
    {
        var result = ListNode.FromObject(Array.Empty<object>());
        Assert.That(result, Is.Null);
    }
}
