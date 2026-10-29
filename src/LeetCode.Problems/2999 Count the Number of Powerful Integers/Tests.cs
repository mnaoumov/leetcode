namespace LeetCode.Problems._2999_Count_the_Number_of_Powerful_Integers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumberOfPowerfulInt(testCase.Start, testCase.Finish, testCase.Limit, testCase.S), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public long Start { get; [UsedImplicitly] init; }
        public long Finish { get; [UsedImplicitly] init; }
        public int Limit { get; [UsedImplicitly] init; }
        public string S { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
