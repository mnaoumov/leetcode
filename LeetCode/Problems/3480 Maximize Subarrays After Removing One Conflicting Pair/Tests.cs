namespace LeetCode.Problems._3480_Maximize_Subarrays_After_Removing_One_Conflicting_Pair;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxSubarrays(testCase.N, testCase.ConflictingPairs), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] ConflictingPairs { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
