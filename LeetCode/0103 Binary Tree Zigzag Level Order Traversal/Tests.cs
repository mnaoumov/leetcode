using JetBrains.Annotations;

namespace LeetCode._0103_Binary_Tree_Zigzag_Level_Order_Traversal;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ZigzagLevelOrder(TreeNode.Create(testCase.RootValues)), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] RootValues { get; [UsedImplicitly] init; } = null!;
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    RootValues = new int?[] { 3, 9, 20, null, null, 15, 7 },
                    Output = new IList<int>[] { new[] { 3 }, new[] { 20, 9 }, new[] { 15, 7 } },
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    RootValues = new int?[] { 1 },
                    Output = new IList<int>[] { new[] { 1 } },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    RootValues = Array.Empty<int?>(),
                    Output = Array.Empty<IList<int>>(),
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}