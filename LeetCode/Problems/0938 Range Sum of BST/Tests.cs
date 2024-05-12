using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._0938_Range_Sum_of_BST;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.RangeSumBST(TreeNode.CreateOrNull(testCase.Root), testCase.Low, testCase.High), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int Low { get; [UsedImplicitly] init; }
        public int High { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
