using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0069_Sqrt_x_;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MySqrt(testCase.X), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int X { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
