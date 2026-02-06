namespace LeetCode.Problems._1305_All_Elements_in_Two_Binary_Search_Trees;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.GetAllElements(TreeNode.CreateOrNull(testCase.Root1), TreeNode.CreateOrNull(testCase.Root2)), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root1 { get; [UsedImplicitly] init; } = null!;
        public int?[] Root2 { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
