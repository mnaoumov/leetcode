namespace LeetCode.Problems._3015_Count_the_Number_of_Houses_at_a_Certain_Distance_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.CountOfPairs(testCase.N, testCase.X, testCase.Y), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int X { get; [UsedImplicitly] init; }
        public int Y { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
