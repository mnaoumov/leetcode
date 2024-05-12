using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._0799_Champagne_Tower;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ChampagneTower(testCase.Poured, testCase.Query_row, testCase.Query_glass), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Poured { get; [UsedImplicitly] init; }
        // ReSharper disable InconsistentNaming
        public int Query_row { get; [UsedImplicitly] init; }
        public int Query_glass { get; [UsedImplicitly] init; }
        // ReSharper restore InconsistentNaming
        public double Output { get; [UsedImplicitly] init; }
    }
}
