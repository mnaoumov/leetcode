using JetBrains.Annotations;

namespace LeetCode.Problems._1110_Delete_Nodes_And_Return_Forest;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.DelNodes(TreeNode.CreateOrNull(testCase.Root), testCase.To_delete).Select(TreeNode.GetValues), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        // ReSharper disable once InconsistentNaming
        public int[] To_delete { get; [UsedImplicitly] init; } = null!;
        public IList<int?[]> Output { get; [UsedImplicitly] init; } = null!;
    }
}
