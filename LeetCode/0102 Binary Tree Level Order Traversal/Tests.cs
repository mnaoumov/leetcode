namespace LeetCode._0102_Binary_Tree_Level_Order_Traversal;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.LevelOrder(TreeNode.Create(testCase.Values)!), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] Values { get; private init; } = null!;
        public IList<IList<int>> Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Values = new int?[] { 3, 9, 20, null, null, 15, 7 },
                    Output = new IList<int>[] { new[] { 3 }, new[] { 9, 20 }, new[] { 15, 7 } },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = new int?[] { 1 },
                    Output = new IList<int>[] { new[] { 1 } },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Values = Array.Empty<int?>(),
                    Output = Array.Empty<IList<int>>(),
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}