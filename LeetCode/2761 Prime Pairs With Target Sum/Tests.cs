using JetBrains.Annotations;

namespace LeetCode._2761_Prime_Pairs_With_Target_Sum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindPrimePairs(testCase.N), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
