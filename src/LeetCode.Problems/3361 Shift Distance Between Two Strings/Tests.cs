namespace LeetCode.Problems._3361_Shift_Distance_Between_Two_Strings;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ShiftDistance(testCase.S, testCase.T, testCase.NextCost, testCase.PreviousCost), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public string T { get; [UsedImplicitly] init; } = null!;
        public int[] NextCost { get; [UsedImplicitly] init; } = null!;
        public int[] PreviousCost { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
