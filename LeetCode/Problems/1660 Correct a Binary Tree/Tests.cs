using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._1660_Correct_a_Binary_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var treeNode = TreeNode.Create(testCase.Root);
        treeNode.FindNode(testCase.FromNode)!.right = treeNode.FindNode(testCase.ToNode);
        Assert.That(solution.CorrectBinaryTree(treeNode), Is.EqualTo(TreeNode.Create(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int FromNode { get; [UsedImplicitly] init; }
        public int ToNode { get; [UsedImplicitly] init; }
        public int?[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
