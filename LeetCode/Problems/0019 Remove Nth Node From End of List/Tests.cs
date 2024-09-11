using NUnit.Framework;

using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0019_Remove_Nth_Node_From_End_of_List;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.RemoveNthFromEnd(ListNode.Create(testCase.HeadValues), testCase.N),
            Is.EqualTo(ListNode.CreateOrNull(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase
    {
        public int[] HeadValues { get; [UsedImplicitly] init; } = null!;
        public int N { get; [UsedImplicitly] init; }
        public int[] OutputValues { get; [UsedImplicitly] init; } = null!;
    }
}
