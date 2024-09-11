using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0077_Combinations;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentIgnoringItemOrderWithDetails(solution.Combine(testCase.N, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
