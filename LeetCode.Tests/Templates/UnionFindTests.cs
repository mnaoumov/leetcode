using LeetCode.Templates;

namespace LeetCode.Tests.Templates;

public class UnionFindTests
{
    [Test]
    public void Find_UnconnectedElement_ReturnsSelf()
    {
        var uf = new UnionFindTemplate.UnionFind<int>();
        Assert.That(uf.Find(1), Is.EqualTo(1));
    }

    [Test]
    public void Connected_BeforeUnion_ReturnsFalse()
    {
        var uf = new UnionFindTemplate.UnionFind<int>();
        Assert.That(uf.Connected(1, 2), Is.False);
    }

    [Test]
    public void Connected_AfterUnion_ReturnsTrue()
    {
        var uf = new UnionFindTemplate.UnionFind<int>();
        uf.Union(1, 2);
        Assert.That(uf.Connected(1, 2), Is.True);
    }

    [Test]
    public void Union_Transitivity()
    {
        var uf = new UnionFindTemplate.UnionFind<int>();
        uf.Union(1, 2);
        uf.Union(2, 3);
        Assert.That(uf.Connected(1, 3), Is.True);
    }

    [Test]
    public void Union_SameElement_NoOp()
    {
        var uf = new UnionFindTemplate.UnionFind<int>();
        uf.Union(1, 1);
        Assert.That(uf.Connected(1, 1), Is.True);
    }

    [Test]
    public void Union_MultipleComponents_StaySeparate()
    {
        var uf = new UnionFindTemplate.UnionFind<int>();
        uf.Union(1, 2);
        uf.Union(3, 4);
        Assert.That(uf.Connected(1, 3), Is.False);
    }

    [Test]
    public void Union_MergeComponents()
    {
        var uf = new UnionFindTemplate.UnionFind<int>();
        uf.Union(1, 2);
        uf.Union(3, 4);
        uf.Union(2, 3);
        Assert.That(uf.Connected(1, 4), Is.True);
    }

    [Test]
    public void Union_WorksWithStrings()
    {
        var uf = new UnionFindTemplate.UnionFind<string>();
        uf.Union("a", "b");
        uf.Union("b", "c");
        Assert.That(uf.Connected("a", "c"), Is.True);
        Assert.That(uf.Connected("a", "d"), Is.False);
    }
}
