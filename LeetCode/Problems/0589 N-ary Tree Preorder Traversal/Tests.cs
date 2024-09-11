
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0589_N_ary_Tree_Preorder_Traversal;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = Node.CreateOrNull(testCase.Root);
        AssertCollectionEqualWithDetails(solution.Preorder(root), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
