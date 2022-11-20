using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._0147_Insertion_Sort_List;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.InsertionSortList(ListNode.Create(testCase.Head)), Is.EqualTo(ListNode.Create(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Head { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
