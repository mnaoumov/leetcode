using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._0111_Minimum_Depth_of_Binary_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        //public int MinDepth(TreeNode root)
        Assert.That(solution.MinDepth(TreeNode.CreateOrNull(testCase.RootValues)), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] RootValues { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
