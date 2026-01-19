namespace LeetCode.Problems._3811_Number_of_Alternating_XOR_Partitions;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.AlternatingXOR(testCase.Nums, testCase.Target1, testCase.Target2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int Target1 { get; [UsedImplicitly] init; }
        public int Target2 { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
