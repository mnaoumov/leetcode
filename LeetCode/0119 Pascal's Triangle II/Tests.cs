using JetBrains.Annotations;

namespace LeetCode._0119_Pascal_s_Triangle_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.GetRow(testCase.RowIndex), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int RowIndex { get; [UsedImplicitly] init; }
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}