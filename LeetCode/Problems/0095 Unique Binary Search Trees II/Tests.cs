using JetBrains.Annotations;

namespace LeetCode.Problems._0095_Unique_Binary_Search_Trees_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.GenerateTrees(testCase.N),
            testCase.OutputValuesArr.Select(TreeNode.CreateOrNull));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int?[][] OutputValuesArr { get; [UsedImplicitly] init; } = null!;
    }
}
