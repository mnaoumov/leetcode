using LeetCode._004_Median_of_Two_Sorted_Arrays;
using NUnit.Framework;

namespace LeetCode.Tests._004_Median_of_Two_Sorted_Arrays;

public class Tests
{
    [Test]
    public void Example1()
    {
        Assert.That(new Solution().FindMedianSortedArrays(new[] { 1, 3 }, new[] { 2 }), Is.EqualTo(2));
    }

    [Test]
    public void Example2()
    {
        Assert.That(new Solution().FindMedianSortedArrays(new[] { 1, 2 }, new[] { 3, 4 }), Is.EqualTo(2.5));
    }

    [Test]
    public void Empty()
    {
        Assert.That(new Solution().FindMedianSortedArrays(new int[] { }, new[] { 1 }), Is.EqualTo(1));
    }

    [Test]
    public void Test1()
    {
        Assert.That(new Solution().FindMedianSortedArrays(new[] { 3 }, new[] { -2, -1 }), Is.EqualTo(-1));
    }
}