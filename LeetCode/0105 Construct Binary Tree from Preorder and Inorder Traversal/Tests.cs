using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0105_Construct_Binary_Tree_from_Preorder_and_Inorder_Traversal;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.BuildTree(testCase.Preorder, testCase.Inorder), Is.EqualTo(TreeNode.Create(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Preorder { get; [UsedImplicitly] init; } = null!;
        public int[] Inorder { get; [UsedImplicitly] init; } = null!;
        public int?[] OutputValues { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Preorder = new[] { 3, 9, 20, 15, 7 },
                    Inorder = new[] { 9, 3, 15, 20, 7 },
                    OutputValues = new int?[] { 3, 9, 20, null, null, 15, 7 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Preorder = new[] { -1 },
                    Inorder = new[] { -1 },
                    OutputValues = new int?[] { -1 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}