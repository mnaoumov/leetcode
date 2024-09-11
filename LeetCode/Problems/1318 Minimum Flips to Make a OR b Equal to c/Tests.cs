using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1318_Minimum_Flips_to_Make_a_OR_b_Equal_to_c;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinFlips(testCase.A, testCase.B, testCase.C), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int A { get; [UsedImplicitly] init; }
        public int B { get; [UsedImplicitly] init; }
        public int C { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
