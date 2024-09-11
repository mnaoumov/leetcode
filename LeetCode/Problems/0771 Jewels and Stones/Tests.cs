using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0771_Jewels_and_Stones;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumJewelsInStones(testCase.Jewels, testCase.Stones), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Jewels { get; [UsedImplicitly] init; } = null!;
        public string Stones { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
