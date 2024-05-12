
using JetBrains.Annotations;

namespace LeetCode.Problems._0863_All_Nodes_Distance_K_in_Binary_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = TreeNode.Create(testCase.Root);
        var target = root.FindNode(testCase.Target)!;

        AssertCollectionEqualWithDetails(solution.DistanceK(root, target, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int Target { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
