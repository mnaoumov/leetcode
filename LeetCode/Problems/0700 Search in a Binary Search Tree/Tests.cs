using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._0700_Search_in_a_Binary_Search_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SearchBST(TreeNode.Create(testCase.Root), testCase.Val), Is.EqualTo(TreeNode.CreateOrNull(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int Val { get; [UsedImplicitly] init; }
        public int?[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
