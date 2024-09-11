using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._1740_Find_Distance_in_a_Binary_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindDistance(TreeNode.Create(testCase.Root), testCase.P, testCase.Q), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int P { get; [UsedImplicitly] init; }
        public int Q { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
