using NUnit.Framework;

namespace LeetCode._0653_Two_Sum_IV___Input_is_a_BST;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindTarget(TreeNode.Create(testCase.Values)!, testCase.K), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] Values { get; private init; } = null!;
        public int K { get; private init; }
        public bool Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Values = new int?[] { 5, 3, 6, 2, 4, null, 7 },
                    K = 9,
                    Return = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = new int?[] { 5, 3, 6, 2, 4, null, 7 },
                    K = 28,
                    Return = false,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}