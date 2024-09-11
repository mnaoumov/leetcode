using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._2220_Minimum_Bit_Flips_to_Convert_Number;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinBitFlips(testCase.Start, testCase.Goal), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Start { get; [UsedImplicitly] init; }
        public int Goal { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
