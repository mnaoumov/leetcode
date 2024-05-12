using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._1290_Convert_Binary_Number_in_a_Linked_List_to_Integer;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GetDecimalValue(ListNode.Create(testCase.Head)), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Head { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
