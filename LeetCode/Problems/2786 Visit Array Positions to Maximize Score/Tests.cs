using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2786_Visit_Array_Positions_to_Maximize_Score;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxScore(testCase.Nums, testCase.X), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int X { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
