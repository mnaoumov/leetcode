using LeetCode._002_Add_Two_Numbers;
using NUnit.Framework;

namespace LeetCode.Tests._002_Add_Two_Numbers;

[TestFixtureSource(nameof(Solutions))]
public class Tests: TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        var l1 = ListNode.Create(2, 4, 3);
        var l2 = ListNode.Create(5, 6, 4);
        var output = ListNode.Create(7, 0, 8);
        Assert.That(Solution.AddTwoNumbers(l1, l2), Is.EqualTo(output));
    }

    [Test]
    public void Example2()
    {
        var l1 = ListNode.Create(0);
        var l2 = ListNode.Create(0);
        var output = ListNode.Create(0);
        Assert.That(Solution.AddTwoNumbers(l1, l2), Is.EqualTo(output));
    }

    [Test]
    public void Example3()
    {
        var l1 = ListNode.Create(9, 9, 9, 9, 9, 9, 9);
        var l2 = ListNode.Create(9, 9, 9, 9);
        var output = ListNode.Create(8, 9, 9, 9, 0, 0, 0, 1);
        Assert.That(Solution.AddTwoNumbers(l1, l2), Is.EqualTo(output));
    }
}