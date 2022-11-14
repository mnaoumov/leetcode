using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0101_Symmetric_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsSymmetric(TreeNode.Create(testCase.RootValues)!), Is.EqualTo(testCase.Output));
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
                    RootValues = new int?[] { 1, 2, 2, 3, 4, 4, 3 },
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    RootValues = new int?[] { 1, 2, 2, null, 3, null, 3 },
                    Output = false,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}