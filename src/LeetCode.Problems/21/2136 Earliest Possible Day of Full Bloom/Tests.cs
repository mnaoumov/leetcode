namespace LeetCode.Problems._2136_Earliest_Possible_Day_of_Full_Bloom;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.EarliestFullBloom(testCase.PlantTime, testCase.GrowTime), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] PlantTime { get; [UsedImplicitly] init; } = null!;
        public int[] GrowTime { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
