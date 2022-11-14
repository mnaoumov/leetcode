using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0124_Binary_Tree_Maximum_Path_Sum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxPathSum(TreeNode.Create(testCase.Values)!), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] Values { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Values = new int?[] { 1, 2, 3 },
                    Output = 6,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = new int?[] { -10, 9, 20, null, null, 15, 7 },
                    Output = 42,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Values = new int?[] { -3 },
                    Output = -3,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    Values = new int?[] { 2, -1 },
                    Output = 2,
                    TestCaseName = nameof(Solution3)
                };
            }
        }
    }
}