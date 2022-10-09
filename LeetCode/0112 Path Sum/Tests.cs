using NUnit.Framework;

namespace LeetCode._0112_Path_Sum;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.HasPathSum(TreeNode.Create(testCase.TreeNodeValues)!, testCase.TargetSum), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] TreeNodeValues { get; private init; } = null!;
        public int TargetSum { get; private init; }
        public bool Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    TreeNodeValues = new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1 },
                    TargetSum = 22,
                    Return = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    TreeNodeValues = new int?[] { 1, 2, 3 },
                    TargetSum = 5,
                    Return = false,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    TreeNodeValues = Array.Empty<int?>(),
                    TargetSum = 0,
                    Return = false,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}