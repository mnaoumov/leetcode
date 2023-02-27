using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0106_Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.BuildTree(testCase.Inorder, testCase.Postorder), Is.EqualTo(TreeNode.CreateOrNull(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Inorder { get; [UsedImplicitly] init; } = null!;
        public int[] Postorder { get; [UsedImplicitly] init; } = null!;
        public int?[] OutputValues { get; [UsedImplicitly] init; } = null!;
    }
}