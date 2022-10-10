namespace LeetCode._0059_Spiral_Matrix_II;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.GenerateMatrix(testCase.N), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; private init; }
        public int[][] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    N = 3,
                    Output = new[] { new[] { 1, 2, 3 }, new[] { 8, 9, 4 }, new[] { 7, 6, 5 } },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    N = 1,
                    Output = new[] { new[] { 1 } },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}