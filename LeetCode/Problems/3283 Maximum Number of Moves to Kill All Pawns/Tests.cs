namespace LeetCode.Problems._3283_Maximum_Number_of_Moves_to_Kill_All_Pawns;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxMoves(testCase.Kx, testCase.Ky, testCase.Positions), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Kx { get; [UsedImplicitly] init; }
        public int Ky { get; [UsedImplicitly] init; }
        public int[][] Positions { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
