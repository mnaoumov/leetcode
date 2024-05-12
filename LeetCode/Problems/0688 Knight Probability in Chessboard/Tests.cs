using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._0688_Knight_Probability_in_Chessboard;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.KnightProbability(testCase.N, testCase.K, testCase.Row, testCase.Column),
            Is.EqualTo(testCase.Output).Within(1e-5));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public int Row { get; [UsedImplicitly] init; }
        public int Column { get; [UsedImplicitly] init; }
        public double Output { get; [UsedImplicitly] init; }
    }
}
