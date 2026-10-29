namespace LeetCode.Problems._1269_Number_of_Ways_to_Stay_in_the_Same_Place_After_Some_Steps;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumWays(testCase.Steps, testCase.ArrLen), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Steps { get; [UsedImplicitly] init; }
        public int ArrLen { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
