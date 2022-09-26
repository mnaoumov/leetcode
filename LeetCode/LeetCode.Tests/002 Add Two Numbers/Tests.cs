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
        var l1 = BuildListNode(2, 4, 3);
        var l2 = BuildListNode(5, 6, 4);
        var output = BuildListNode(7, 0, 8);
        Assert.That(Solution.AddTwoNumbers(l1, l2), Is.EqualTo(output));
    }

    [Test]
    public void Example2()
    {
        var l1 = BuildListNode(0);
        var l2 = BuildListNode(0);
        var output = BuildListNode(0);
        Assert.That(Solution.AddTwoNumbers(l1, l2), Is.EqualTo(output));
    }

    [Test]
    public void Example3()
    {
        var l1 = BuildListNode(9, 9, 9, 9, 9, 9, 9);
        var l2 = BuildListNode(9, 9, 9, 9);
        var output = BuildListNode(8, 9, 9, 9, 0, 0, 0, 1);
        Assert.That(Solution.AddTwoNumbers(l1, l2), Is.EqualTo(output));
    }

    private static ListNode? BuildListNode(params int[] values)
    {
        ListNode? listNode = null;
        for (var i = values.Length - 1; i >= 0; i--)
        {
            listNode = new ListNode(values[i], listNode);
        }

        return listNode;
    }
}