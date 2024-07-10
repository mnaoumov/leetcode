using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2977_Minimum_Cost_to_Convert_String_II;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumCost(testCase.Source, testCase.Target, testCase.Original, testCase.Changed, testCase.Cost), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Source { get; [UsedImplicitly] init; } = null!;
        public string Target { get; [UsedImplicitly] init; } = null!;
        public string[] Original { get; [UsedImplicitly] init; } = null!;
        public string[] Changed { get; [UsedImplicitly] init; } = null!;
        public int[] Cost { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
