namespace LeetCode.Problems._3864_Minimum_Cost_to_Partition_a_Binary_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinCost(testCase.S, testCase.EncCost, testCase.FlatCost), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public int EncCost { get; [UsedImplicitly] init; }
        public int FlatCost { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
