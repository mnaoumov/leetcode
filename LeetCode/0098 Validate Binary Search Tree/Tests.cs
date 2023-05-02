using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0098_Validate_Binary_Search_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsValidBST(TreeNode.Create(testCase.Values)), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Values { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
