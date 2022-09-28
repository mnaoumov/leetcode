using NUnit.Framework;

namespace LeetCode._019_Remove_Nth_Node_From_End_of_List;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.RemoveNthFromEnd(ListNode.Create(1, 2, 3, 4, 5), 2),
            Is.EqualTo(ListNode.Create(1, 2, 3, 5)));
    }

    [Test]
    public void Example2()
    {
        Assert.That(Solution.RemoveNthFromEnd(ListNode.Create(1), 1), Is.Null);
    }

    [Test]
    public void Example3()
    {
        Assert.That(Solution.RemoveNthFromEnd(ListNode.Create(1, 2), 1), Is.EqualTo(ListNode.Create(1)));
    }
}