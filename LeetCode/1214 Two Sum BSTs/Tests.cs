using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._1214_Two_Sum_BSTs;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.TwoSumBSTs(TreeNode.Create(testCase.Root1), TreeNode.Create(testCase.Root2), testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root1 { get; [UsedImplicitly] init; } = null!;
        public int?[] Root2 { get; [UsedImplicitly] init; } = null!;
        public int Target { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }
    }
}
