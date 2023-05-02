using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0050_Pow_x__n_;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MyPow(testCase.X, testCase.N), Is.EqualTo(testCase.Output).Within(1e-10));
    }

    public class TestCase : TestCaseBase
    {
        public double X { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public double Output { get; [UsedImplicitly] init; }
    }
}
