namespace LeetCode._0054_Spiral_Matrix;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.SpiralOrder(testCase.Matrix), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] Matrix { get; private init; } = null!;
        public IList<int> Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Matrix = new[] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 } },
                    Output = new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Matrix = new[] { new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 }, new[] { 9, 10, 11, 12 } },
                    Output = new[] { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}