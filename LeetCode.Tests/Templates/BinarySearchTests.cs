using LeetCode.Templates;

namespace LeetCode.Tests.Templates;

public class BinarySearchTests
{
    [Test]
    public void BinarySearchFirst_FindsFirstOccurrence()
    {
        int[] arr = [1, 2, 2, 2, 3, 4];
        Assert.That(BinarySearch.BinarySearchFirst(arr, 2), Is.EqualTo(1));
    }

    [Test]
    public void BinarySearchFirst_NotFound_ReturnsInsertionPoint()
    {
        int[] arr = [1, 3, 5, 7];
        Assert.That(BinarySearch.BinarySearchFirst(arr, 4), Is.EqualTo(2));
    }

    [Test]
    public void BinarySearchFirst_BeforeAll_ReturnsZero()
    {
        int[] arr = [2, 3, 4];
        Assert.That(BinarySearch.BinarySearchFirst(arr, 1), Is.EqualTo(0));
    }

    [Test]
    public void BinarySearchFirst_AfterAll_ReturnsLength()
    {
        int[] arr = [1, 2, 3];
        Assert.That(BinarySearch.BinarySearchFirst(arr, 5), Is.EqualTo(3));
    }

    [Test]
    public void BinarySearchFirst_WithRange()
    {
        int[] arr = [1, 2, 3, 4, 5];
        Assert.That(BinarySearch.BinarySearchFirst(arr, 3, 1, 3), Is.EqualTo(2));
    }

    [Test]
    public void BinarySearchLast_FindsLastOccurrence()
    {
        int[] arr = [1, 2, 2, 2, 3, 4];
        Assert.That(BinarySearch.BinarySearchLast(arr, 2), Is.EqualTo(3));
    }

    [Test]
    public void BinarySearchLast_NotFound_ReturnsBeforeInsertionPoint()
    {
        int[] arr = [1, 3, 5, 7];
        Assert.That(BinarySearch.BinarySearchLast(arr, 4), Is.EqualTo(1));
    }

    [Test]
    public void BinarySearchLast_BeforeAll_ReturnsMinusOne()
    {
        int[] arr = [2, 3, 4];
        Assert.That(BinarySearch.BinarySearchLast(arr, 1), Is.EqualTo(-1));
    }

    [Test]
    public void BinarySearchLast_AfterAll_ReturnsLastIndex()
    {
        int[] arr = [1, 2, 3];
        Assert.That(BinarySearch.BinarySearchLast(arr, 5), Is.EqualTo(2));
    }

    [Test]
    public void BinarySearchLast_WithRange()
    {
        int[] arr = [1, 2, 3, 4, 5];
        Assert.That(BinarySearch.BinarySearchLast(arr, 3, 1, 3), Is.EqualTo(2));
    }

    [Test]
    public void BinarySearch_SingleElement_Found()
    {
        int[] arr = [5];
        Assert.That(BinarySearch.BinarySearchFirst(arr, 5), Is.EqualTo(0));
        Assert.That(BinarySearch.BinarySearchLast(arr, 5), Is.EqualTo(0));
    }

    [Test]
    public void BinarySearch_CountOccurrences()
    {
        int[] arr = [1, 2, 2, 2, 2, 3];
        var first = BinarySearch.BinarySearchFirst(arr, 2);
        var last = BinarySearch.BinarySearchLast(arr, 2);
        Assert.That(last - first + 1, Is.EqualTo(4));
    }
}
