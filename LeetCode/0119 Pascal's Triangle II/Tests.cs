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

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    RowIndex = 3,
                    Output = new[] { 1, 3, 3, 1 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    RowIndex = 0,
                    Output = new[] { 1 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    RowIndex = 1,
                    Output = new[] { 1, 1 },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
