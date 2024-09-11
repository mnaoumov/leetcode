namespace LeetCode.Problems._2037_Minimum_Number_of_Moves_to_Seat_Everyone;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinMovesToSeat(testCase.Seats, testCase.Students), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Seats { get; [UsedImplicitly] init; } = null!;
        public int[] Students { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
