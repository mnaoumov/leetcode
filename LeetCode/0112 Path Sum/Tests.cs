using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0112_Path_Sum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.HasPathSum(TreeNode.CreateOrNull(testCase.TreeNodeValues), testCase.TargetSum), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] TreeNodeValues { get; [UsedImplicitly] init; } = null!;
        public int TargetSum { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }
    }
}
