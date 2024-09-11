using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0567_Permutation_in_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CheckInclusion(testCase.S1, testCase.S2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S1 { get; [UsedImplicitly] init; } = null!;
        public string S2 { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
