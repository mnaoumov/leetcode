using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._0572_Subtree_of_Another_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsSubtree(TreeNode.Create(testCase.Root), TreeNode.Create(testCase.SubRoot)), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int?[] SubRoot { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
