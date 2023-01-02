
using JetBrains.Annotations;

namespace LeetCode._0797_All_Paths_From_Source_to_Target;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.AllPathsSourceTarget(testCase.Graph), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Graph { get; [UsedImplicitly] init; } = null!;
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
