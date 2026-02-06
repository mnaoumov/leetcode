namespace LeetCode.Problems._0286_Walls_and_Gates;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        var rooms = ArrayHelper.DeepCopy(testCase.Rooms);
        solution.WallsAndGates(rooms);
        AssertCollectionEqualWithDetails(rooms, testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Rooms { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
