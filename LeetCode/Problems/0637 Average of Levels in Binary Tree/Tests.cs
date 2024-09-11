
using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0637_Average_of_Levels_in_Binary_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.AverageOfLevels(TreeNode.Create(testCase.Root)), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public IList<double> Output { get; [UsedImplicitly] init; } = null!;
    }
}
