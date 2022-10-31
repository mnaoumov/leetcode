using JetBrains.Annotations;

namespace LeetCode._0113_Path_Sum_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.PathSum(TreeNode.Create(testCase.RootValues), testCase.TargetSum), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] RootValues { get; private init; } = null!;
        public int TargetSum { get; private init; }
        public IList<IList<int>> Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    RootValues = new int?[]
                    {
                        5, 4, 8, 11, null, 13, 4, 7, 2, null, null, 5, 1
                    },
                    TargetSum = 22,
                    Output = new IList<int>[]
                    {
                        new[] { 5, 4, 11, 2 }, new[] { 5, 8, 4, 5 }
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    RootValues = new int?[] { 1, 2, 3 },
                    TargetSum = 5,
                    Output = Array.Empty<IList<int>>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    RootValues = new int?[] { 1, 2 },
                    TargetSum = 0,
                    Output = Array.Empty<IList<int>>(),
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    RootValues = Array.Empty<int?>(),
                    TargetSum = 1,
                    Output = Array.Empty<IList<int>>(),
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}
