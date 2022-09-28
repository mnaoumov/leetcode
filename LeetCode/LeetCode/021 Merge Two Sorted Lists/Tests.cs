using NUnit.Framework;

namespace LeetCode._021_Merge_Two_Sorted_Lists;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.MergeTwoLists(ListNode.Create(1, 2, 4), ListNode.Create(1, 3, 4)), Is.EqualTo(ListNode.Create(1, 1, 2, 3, 4, 4)));
    }
}