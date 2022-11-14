using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0099_Recover_Binary_Search_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = TreeNode.Create(testCase.RootValues)!;
        solution.RecoverTree(root);

        Assert.That(root, Is.EqualTo(TreeNode.Create(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] RootValues { get; [UsedImplicitly] init; } = null!;
        public int?[] OutputValues { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    RootValues = new int?[] { 1, 3, null, null, 2 },
                    OutputValues = new int?[] { 3, 1, null, null, 2 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    RootValues = new int?[] { 3, 1, 4, null, null, 2 },
                    OutputValues = new int?[] { 2, 1, 4, null, null, 3 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    RootValues = new int?[] { 2, 3, 1 },
                    OutputValues = new int?[] { 2, 1, 3 },
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}