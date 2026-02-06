namespace LeetCode.Problems._1283_Find_the_Smallest_Divisor_Given_a_Threshold;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SmallestDivisor(testCase.Nums, testCase.Threshold), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int Threshold { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
