namespace LeetCode.Problems._3842_Toggle_Light_Bulbs;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ToggleLightBulbs(testCase.Bulbs), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public IList<int> Bulbs { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
