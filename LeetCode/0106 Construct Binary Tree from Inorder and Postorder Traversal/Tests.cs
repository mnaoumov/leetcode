using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0106_Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.BuildTree(testCase.Inorder, testCase.Postorder), Is.EqualTo(TreeNode.Create(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Inorder { get; [UsedImplicitly] init; } = null!;
        public int[] Postorder { get; [UsedImplicitly] init; } = null!;
        public int?[] OutputValues { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Inorder = new[] { 9, 3, 15, 20, 7 },
                    Postorder = new[] { 9, 15, 7, 20, 3 },
                    OutputValues = new int?[] { 3, 9, 20, null, null, 15, 7 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Inorder = new[] { -1 },
                    Postorder = new[] { -1 },
                    OutputValues = new int?[] { -1 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}