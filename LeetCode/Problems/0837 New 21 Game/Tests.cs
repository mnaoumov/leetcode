using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._0837_New_21_Game;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.New21Game(testCase.N, testCase.K, testCase.MaxPts),
            Is.EqualTo(testCase.Output).Within(1e-5));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public int MaxPts { get; [UsedImplicitly] init; }
        public double Output { get; [UsedImplicitly] init; }
    }
}
