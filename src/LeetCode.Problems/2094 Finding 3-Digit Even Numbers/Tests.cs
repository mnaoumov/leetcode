namespace LeetCode.Problems._2094_Finding_3_Digit_Even_Numbers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindEvenNumbers(testCase.Digits), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Digits { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
