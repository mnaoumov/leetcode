namespace LeetCode.Problems._1642_Furthest_Building_You_Can_Reach;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FurthestBuilding(testCase.Heights, testCase.Bricks, testCase.Ladders), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Heights { get; [UsedImplicitly] init; } = null!;
        public int Bricks { get; [UsedImplicitly] init; }
        public int Ladders { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
