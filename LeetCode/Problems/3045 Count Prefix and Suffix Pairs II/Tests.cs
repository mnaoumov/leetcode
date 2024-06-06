using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._3045_Count_Prefix_and_Suffix_Pairs_II;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountPrefixSuffixPairs(testCase.Words), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Words { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
