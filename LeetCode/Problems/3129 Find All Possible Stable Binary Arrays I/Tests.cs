namespace LeetCode.Problems._3129_Find_All_Possible_Stable_Binary_Arrays_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumberOfStableArrays(testCase.Zero, testCase.One, testCase.Limit), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Zero { get; [UsedImplicitly] init; }
        public int One { get; [UsedImplicitly] init; }
        public int Limit { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
