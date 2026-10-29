namespace LeetCode.Problems._0762_Prime_Number_of_Set_Bits_in_Binary_Representation;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountPrimeSetBits(testCase.Left, testCase.Right), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Left { get; [UsedImplicitly] init; }
        public int Right { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
