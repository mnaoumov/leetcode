namespace LeetCode.Problems._1652_Defuse_the_Bomb;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.Decrypt(testCase.Code, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Code { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
