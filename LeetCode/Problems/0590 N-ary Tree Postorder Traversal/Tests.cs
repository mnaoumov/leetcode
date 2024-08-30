using JetBrains.Annotations;

namespace LeetCode.Problems._0590_N_ary_Tree_Postorder_Traversal;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = Node.CreateOrNull(testCase.Root);

        AssertCollectionEqualWithDetails(solution.Postorder(root), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
