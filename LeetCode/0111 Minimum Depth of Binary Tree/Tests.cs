using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0111_Minimum_Depth_of_Binary_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        //public int MinDepth(TreeNode root)
        Assert.That(solution.MinDepth(TreeNode.Create(testCase.RootValues)), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] RootValues { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    RootValues = new int?[] { 3, 9, 20, null, null, 15, 7 },
                    Output = 2,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    RootValues = new int?[] { 2, null, 3, null, 4, null, 5, null, 6 },
                    Output = 5,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}