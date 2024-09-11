using NUnit.Framework;

using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0129_Sum_Root_to_Leaf_Numbers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SumNumbers(TreeNode.Create(testCase.RootValues)), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] RootValues { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
