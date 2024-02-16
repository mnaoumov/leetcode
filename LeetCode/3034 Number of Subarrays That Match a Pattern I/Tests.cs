using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._3034_Number_of_Subarrays_That_Match_a_Pattern_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountMatchingSubarrays(testCase.Nums, testCase.Pattern), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int[] Pattern { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
