using JetBrains.Annotations;

namespace LeetCode._0095_Unique_Binary_Search_Trees_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.GenerateTrees(testCase.N),
            testCase.OutputValuesArr.Select(TreeNode.Create));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; [UsedImplicitly] init; }
        public int?[][] OutputValuesArr { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    N = 3,
                    OutputValuesArr = new[]
                    {
                        new int?[] { 1, null, 2, null, 3 },
                        new int?[] { 1, null, 3, 2 },
                        new int?[] { 2, 1, 3 },
                        new int?[] { 3, 1, null, null, 2 },
                        new int?[] { 3, 2, null, 1 }
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    N = 1,
                    OutputValuesArr = new[]
                    {
                        new int?[] { 1 }
                    },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}