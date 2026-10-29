namespace LeetCode.Problems._3076_Shortest_Uncommon_Substring_in_an_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ShortestSubstrings(testCase.Arr), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string[] Arr { get; [UsedImplicitly] init; } = null!;
        public string[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
