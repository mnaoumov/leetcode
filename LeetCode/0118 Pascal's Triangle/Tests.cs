using JetBrains.Annotations;

namespace LeetCode._0118_Pascal_s_Triangle;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.Generate(testCase.NumRows), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int NumRows { get; [UsedImplicitly] init; }
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
