using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1552_Magnetic_Force_Between_Two_Balls;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxDistance(testCase.Position, testCase.M), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Position { get; [UsedImplicitly] init; } = null!;
        public int M { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
