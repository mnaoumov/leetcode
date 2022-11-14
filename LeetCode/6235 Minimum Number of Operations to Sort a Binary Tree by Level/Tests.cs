using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._6235_Minimum_Number_of_Operations_to_Sort_a_Binary_Tree_by_Level;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumOperations(TreeNode.Create(testCase.RootValues)), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] RootValues { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    RootValues = new int?[]
                    {
                        1, 4, 3, 7, 6, 8, 5, null, null, null,
                        null, 9, null, 10
                    },
                    Output = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    RootValues = new int?[] { 1, 3, 2, 7, 6, 5, 4 },
                    Output = 3,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    RootValues = new int?[] { 1, 2, 3, 4, 5, 6 },
                    Output = 0,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
