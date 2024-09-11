using NUnit.Framework;

using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._2095_Delete_the_Middle_Node_of_a_Linked_List;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.DeleteMiddle(ListNode.Create(testCase.Values)), Is.EqualTo(ListNode.Create(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Values { get; [UsedImplicitly] init; } = null!;
        public int[] OutputValues { get; [UsedImplicitly] init; } = null!;
    }
}
