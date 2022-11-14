using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0110_Balanced_Binary_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsBalanced(TreeNode.Create(testCase.RootValues)), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] RootValues { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    RootValues = new int?[] { 3, 9, 20, null, null, 15, 7 },
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    RootValues = new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 },
                    Output = false,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    RootValues = Array.Empty<int?>(),
                    Output = true,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}