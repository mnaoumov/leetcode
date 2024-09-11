using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;
using NUnit.Framework;

namespace LeetCode.Problems._2181_Merge_Nodes_in_Between_Zeros;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MergeNodes(ListNode.Create(testCase.Head)), Is.EqualTo(ListNode.Create(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Head { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
