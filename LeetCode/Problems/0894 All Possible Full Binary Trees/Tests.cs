using JetBrains.Annotations;

namespace LeetCode._0894_All_Possible_Full_Binary_Trees;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.AllPossibleFBT(testCase.N),
            testCase.Output.Select(TreeNode.Create));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public IList<int?[]> Output { get; [UsedImplicitly] init; } = null!;
    }
}
