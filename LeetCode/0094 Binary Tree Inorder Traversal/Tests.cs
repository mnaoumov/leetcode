using JetBrains.Annotations;

namespace LeetCode._0094_Binary_Tree_Inorder_Traversal;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.InorderTraversal(TreeNode.Create(testCase.Values)), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] Values { get; private init; } = null!;
        public int[] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Values = new int?[] { 1, null, 2, 3 },
                    Output = new[] { 1, 3, 2 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = Array.Empty<int?>(),
                    Output = Array.Empty<int>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Values = new int?[] { 1 },
                    Output = new[] { 1 },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}