using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._2487_Remove_Nodes_From_Linked_List;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.RemoveNodes(ListNode.Create(testCase.Head)), Is.EqualTo(ListNode.Create(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Head { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
