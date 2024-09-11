using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0270_Closest_Binary_Search_Tree_Value;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ClosestValue(TreeNode.Create(testCase.Root), testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public double Target { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
