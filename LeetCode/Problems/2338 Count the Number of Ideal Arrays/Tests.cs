namespace LeetCode.Problems._2338_Count_the_Number_of_Ideal_Arrays;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IdealArrays(testCase.N, testCase.MaxValue), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int MaxValue { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
