namespace LeetCode.Problems._2894_Divisible_and_Non_divisible_Sums_Difference;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.DifferenceOfSums(testCase.N, testCase.M), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int M { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
