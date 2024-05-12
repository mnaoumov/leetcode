using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._3043_Find_the_Length_of_the_Longest_Common_Prefix;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LongestCommonPrefix(testCase.Arr1, testCase.Arr2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Arr1 { get; [UsedImplicitly] init; } = null!;
        public int[] Arr2 { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
