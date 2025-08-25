namespace LeetCode.Problems._3661_Maximum_Walls_Destroyed_by_Robots;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxWalls(testCase.Robots, testCase.Distance, testCase.Walls), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Robots { get; [UsedImplicitly] init; } = null!;
        public int[] Distance { get; [UsedImplicitly] init; } = null!;
        public int[] Walls { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
