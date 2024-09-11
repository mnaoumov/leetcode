namespace LeetCode.Problems._2719_Count_of_Integers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Count(testCase.Num1, testCase.Num2, testCase.Min_sum, testCase.Max_sum), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Num1 { get; [UsedImplicitly] init; } = null!;
        public string Num2 { get; [UsedImplicitly] init; } = null!;
        // ReSharper disable InconsistentNaming
        public int Min_sum { get; [UsedImplicitly] init; }
        public int Max_sum { get; [UsedImplicitly] init; }
        // ReSharper restore InconsistentNaming
        public int Output { get; [UsedImplicitly] init; }
    }
}
