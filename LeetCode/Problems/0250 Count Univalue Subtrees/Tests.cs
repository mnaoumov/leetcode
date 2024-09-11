using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0250_Count_Univalue_Subtrees;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountUnivalSubtrees(TreeNode.CreateOrNull(testCase.Root)), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
