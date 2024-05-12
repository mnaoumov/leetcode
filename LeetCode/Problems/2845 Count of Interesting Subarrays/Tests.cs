using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2845_Count_of_Interesting_Subarrays;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountInterestingSubarrays(testCase.Nums, testCase.Modulo, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public IList<int> Nums { get; [UsedImplicitly] init; } = null!;
        public int Modulo { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
