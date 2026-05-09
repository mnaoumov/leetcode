namespace LeetCode.Problems._1018201_Score_Validator;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ScoreValidator(testCase.Events), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string[] Events { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
