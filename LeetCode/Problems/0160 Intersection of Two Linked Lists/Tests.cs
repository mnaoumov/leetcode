using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0160_Intersection_of_Two_Linked_Lists;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var listA = ListNode.Create(testCase.ListA);
        var listB = ListNode.Create(testCase.ListB);

        if (testCase.IntersectVal != 0)
        {
            var nodeA = listA;
            for (var i = 1; i <= testCase.SkipA - 1; i++)
            {
                nodeA = nodeA!.next;
            }

            var nodeB = listB;
            for (var i = 1; i <= testCase.SkipB - 1; i++)
            {
                nodeB = nodeB!.next;
            }

            nodeB!.next = nodeA!.next;
        }
        Assert.That(solution.GetIntersectionNode(listA, listB), Is.EqualTo(ListNode.CreateOrNull(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int IntersectVal { get; [UsedImplicitly] init; }
        public int[] ListA { get; [UsedImplicitly] init; } = null!;
        public int[] ListB { get; [UsedImplicitly] init; } = null!;
        public int SkipA { get; [UsedImplicitly] init; }
        public int SkipB { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
