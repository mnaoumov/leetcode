using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0105_Construct_Binary_Tree_from_Preorder_and_Inorder_Traversal;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.BuildTree(testCase.Preorder, testCase.Inorder), Is.EqualTo(TreeNode.CreateOrNull(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Preorder { get; [UsedImplicitly] init; } = null!;
        public int[] Inorder { get; [UsedImplicitly] init; } = null!;
        public int?[] OutputValues { get; [UsedImplicitly] init; } = null!;
    }
}