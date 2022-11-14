using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0107_Binary_Tree_Level_Order_Traversal_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LevelOrderBottom(TreeNode.Create(testCase.RootValues)), Is.EqualTo(testCase.Output));
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
                    Output = new IList<int>[] { new[] { 15, 7 }, new[] { 9, 20 }, new[] { 3 } },
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