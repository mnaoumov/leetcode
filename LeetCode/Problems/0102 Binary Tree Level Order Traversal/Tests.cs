using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0102_Binary_Tree_Level_Order_Traversal;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.LevelOrder(TreeNode.CreateOrNull(testCase.Values)), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Values { get; [UsedImplicitly] init; } = null!;
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
