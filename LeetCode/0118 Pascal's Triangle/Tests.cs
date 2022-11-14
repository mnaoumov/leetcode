using JetBrains.Annotations;

namespace LeetCode._0118_Pascal_s_Triangle;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.Generate(testCase.NumRows), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int NumRows { get; [UsedImplicitly] init; }
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    NumRows = 5,
                    Output = new IList<int>[]
                    {
                        new[] { 1 }, new[] { 1, 1 }, new[] { 1, 2, 1 }, new[] { 1, 3, 3, 1 }, new[] { 1, 4, 6, 4, 1 }
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    NumRows = 1,
                    Output = new IList<int>[]
                    {
                        new[] { 1 }
                    },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
