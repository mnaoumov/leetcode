using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0617_Merge_Two_Binary_Trees;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MergeTrees(TreeNode.CreateOrNull(testCase.Root1), TreeNode.CreateOrNull(testCase.Root2)), Is.EqualTo(TreeNode.CreateOrNull(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root1 { get; [UsedImplicitly] init; } = null!;
        public int?[] Root2 { get; [UsedImplicitly] init; } = null!;
        public int?[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
