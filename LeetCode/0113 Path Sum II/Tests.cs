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
        public int?[] RootValues { get; [UsedImplicitly] init; } = null!;
        public int TargetSum { get; [UsedImplicitly] init; }
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}