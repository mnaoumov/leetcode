namespace LeetCode.Problems._2433_Find_The_Original_Array_of_Prefix_Xor;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindArray(testCase.Pref), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Pref { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
