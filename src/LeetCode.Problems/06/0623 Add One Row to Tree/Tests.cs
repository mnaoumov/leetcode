namespace LeetCode.Problems._0623_Add_One_Row_to_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.AddOneRow(TreeNode.Create(testCase.ValuesBefore), testCase.Val, testCase.Depth),
            Is.EqualTo(TreeNode.CreateOrNull(testCase.ValuesAfter)));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] ValuesBefore { get; [UsedImplicitly] init; } = null!;
        public int?[] ValuesAfter { get; [UsedImplicitly] init; } = null!;
        public int Val { get; [UsedImplicitly] init; }
        public int Depth { get; [UsedImplicitly] init; }
    }
}
