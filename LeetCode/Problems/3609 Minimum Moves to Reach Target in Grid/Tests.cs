namespace LeetCode.Problems._3609_Minimum_Moves_to_Reach_Target_in_Grid;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinMoves(testCase.Sx, testCase.Sy, testCase.Tx, testCase.Ty), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Sx { get; [UsedImplicitly] init; }
        public int Sy { get; [UsedImplicitly] init; }
        public int Tx { get; [UsedImplicitly] init; }
        public int Ty { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
