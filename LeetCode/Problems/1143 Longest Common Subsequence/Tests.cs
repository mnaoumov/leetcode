using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._1143_Longest_Common_Subsequence;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LongestCommonSubsequence(testCase.Text1, testCase.Text2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Text1 { get; [UsedImplicitly] init; } = null!;
        public string Text2 { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
