using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._3276_Select_Cells_in_Grid_With_Maximum_Score;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxScore(testCase.Grid), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public IList<IList<int>> Grid { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
