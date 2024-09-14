namespace LeetCode.Problems._3285_Find_Indices_of_Stable_Mountains;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.StableMountains(testCase.Height, testCase.Threshold), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Height { get; [UsedImplicitly] init; } = null!;
        public int Threshold { get; [UsedImplicitly] init; }
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
