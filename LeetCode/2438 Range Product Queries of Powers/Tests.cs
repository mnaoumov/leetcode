using JetBrains.Annotations;

namespace LeetCode._2438_Range_Product_Queries_of_Powers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ProductQueries(testCase.N, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; private init; }
        public int[][] Queries { get; private init; } = null!;
        public int[] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {

                    N = 15,
                    Queries = new[] { new[] { 0, 1 }, new[] { 2, 2 }, new[] { 0, 3 } },
                    Output = new[] { 2, 4, 64 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {

                    N = 2,
                    Queries = new[] { new[] { 0, 0 } },
                    Output = new[] { 2 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}