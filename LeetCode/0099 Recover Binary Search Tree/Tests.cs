using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0099_Recover_Binary_Search_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = TreeNode.Create(testCase.RootValues)!;
        solution.RecoverTree(root);

        Assert.That(root, Is.EqualTo(TreeNode.Create(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] RootValues { get; [UsedImplicitly] init; } = null!;
        public int?[] OutputValues { get; [UsedImplicitly] init; } = null!;
    }
}