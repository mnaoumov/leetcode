using LeetCode.Templates;

namespace LeetCode.Tests.Templates;

public class HashableImmutableArrayTests
{
    [Test]
    public void Count_ReturnsLength()
    {
        var arr = new HashableImmutableArrayTemplate.HashableImmutableArray<int>([1, 2, 3]);
        Assert.That(arr.Count, Is.EqualTo(3));
    }

    [Test]
    public void Indexer_ReturnsCorrectElement()
    {
        var arr = new HashableImmutableArrayTemplate.HashableImmutableArray<int>([10, 20, 30]);
        Assert.That(arr[0], Is.EqualTo(10));
        Assert.That(arr[1], Is.EqualTo(20));
        Assert.That(arr[2], Is.EqualTo(30));
    }

    [Test]
    public void Enumeration_YieldsAllElements()
    {
        var arr = new HashableImmutableArrayTemplate.HashableImmutableArray<int>([1, 2, 3]);
        Assert.That(arr.ToList(), Is.EqualTo(new[] { 1, 2, 3 }));
    }

    [Test]
    public void Equals_SameContents_ReturnsTrue()
    {
        var a = new HashableImmutableArrayTemplate.HashableImmutableArray<int>([1, 2, 3]);
        var b = new HashableImmutableArrayTemplate.HashableImmutableArray<int>([1, 2, 3]);
        Assert.That(a, Is.EqualTo(b));
    }

    [Test]
    public void Equals_DifferentContents_ReturnsFalse()
    {
        var a = new HashableImmutableArrayTemplate.HashableImmutableArray<int>([1, 2, 3]);
        var b = new HashableImmutableArrayTemplate.HashableImmutableArray<int>([1, 2, 4]);
        Assert.That(a, Is.Not.EqualTo(b));
    }

    [Test]
    public void Equals_Self_ReturnsTrue()
    {
        var a = new HashableImmutableArrayTemplate.HashableImmutableArray<int>([1, 2]);
        Assert.That(a.Equals(a), Is.True);
    }

    [Test]
    public void GetHashCode_SameContents_SameHash()
    {
        var a = new HashableImmutableArrayTemplate.HashableImmutableArray<int>([1, 2, 3]);
        var b = new HashableImmutableArrayTemplate.HashableImmutableArray<int>([1, 2, 3]);
        Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
    }

    [Test]
    public void GetHashCode_DifferentContents_DifferentHash()
    {
        var a = new HashableImmutableArrayTemplate.HashableImmutableArray<int>([1, 2, 3]);
        var b = new HashableImmutableArrayTemplate.HashableImmutableArray<int>([3, 2, 1]);
        Assert.That(a.GetHashCode(), Is.Not.EqualTo(b.GetHashCode()));
    }

    [Test]
    public void WorksAsDictionaryKey()
    {
        var dict = new Dictionary<HashableImmutableArrayTemplate.HashableImmutableArray<int>, string>();
        var key1 = new HashableImmutableArrayTemplate.HashableImmutableArray<int>([1, 2]);
        dict[key1] = "hello";

        var key2 = new HashableImmutableArrayTemplate.HashableImmutableArray<int>([1, 2]);
        Assert.That(dict[key2], Is.EqualTo("hello"));
    }

    [Test]
    public void IsImmutable_OriginalArrayMutationDoesNotAffect()
    {
        var source = new[] { 1, 2, 3 };
        var arr = new HashableImmutableArrayTemplate.HashableImmutableArray<int>(source);
        source[0] = 99;
        Assert.That(arr[0], Is.EqualTo(1));
    }
}
