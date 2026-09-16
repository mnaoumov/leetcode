namespace LeetCode.Problems._1762_Buildings_With_an_Ocean_View;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindBuildings(testCase.Heights), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Heights { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
