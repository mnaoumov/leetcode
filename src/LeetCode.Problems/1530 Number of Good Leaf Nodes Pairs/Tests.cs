namespace LeetCode.Problems._1530_Number_of_Good_Leaf_Nodes_Pairs;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountPairs(TreeNode.Create(testCase.Root), testCase.Distance), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int Distance { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
