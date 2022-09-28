using System.Net.Http.Headers;
using NUnit.Framework;

namespace LeetCode._023_Merge_k_Sorted_Lists;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.MergeKLists(new[]
        {
            ListNode.Create(1, 4, 5),
            ListNode.Create(1, 3, 4),
            ListNode.Create(2, 6)
        }), Is.EqualTo(ListNode.Create(1, 1, 2, 3, 4, 4, 5, 6)));
    }

    [Test]
    public void Example2()
    {
        Assert.That(Solution.MergeKLists(Array.Empty<ListNode>()), Is.Null);
    }

    [Test]
    public void Example3()
    {
        Assert.That(Solution.MergeKLists(new ListNode?[] { null }), Is.Null);
    }
}