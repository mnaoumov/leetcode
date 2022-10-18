using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0112_Path_Sum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.HasPathSum(TreeNode.Create(testCase.TreeNodeValues)!, testCase.TargetSum), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] TreeNodeValues { get; private init; } = null!;
        public int TargetSum { get; private init; }
        public bool Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    TreeNodeValues = new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1 },
                    TargetSum = 22,
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    TreeNodeValues = new int?[] { 1, 2, 3 },
                    TargetSum = 5,
                    Output = false,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    TreeNodeValues = Array.Empty<int?>(),
                    TargetSum = 0,
                    Output = false,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}