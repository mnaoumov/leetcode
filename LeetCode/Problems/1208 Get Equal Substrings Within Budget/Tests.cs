using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1208_Get_Equal_Substrings_Within_Budget;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.EqualSubstring(testCase.S, testCase.T, testCase.MaxCost), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public string T { get; [UsedImplicitly] init; } = null!;
        public int MaxCost { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
