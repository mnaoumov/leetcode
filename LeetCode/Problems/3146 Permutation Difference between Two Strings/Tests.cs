using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._3146_Permutation_Difference_between_Two_Strings;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindPermutationDifference(testCase.S, testCase.T), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public string T { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
