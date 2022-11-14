using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0653_Two_Sum_IV___Input_is_a_BST;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindTarget(TreeNode.Create(testCase.Values)!, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] Values { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Values = new int?[] { 5, 3, 6, 2, 4, null, 7 },
                    K = 9,
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = new int?[] { 5, 3, 6, 2, 4, null, 7 },
                    K = 28,
                    Output = false,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}