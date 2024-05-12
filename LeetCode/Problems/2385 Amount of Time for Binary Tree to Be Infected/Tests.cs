using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._2385_Amount_of_Time_for_Binary_Tree_to_Be_Infected;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.AmountOfTime(TreeNode.Create(testCase.Root), testCase.Start), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int Start { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
