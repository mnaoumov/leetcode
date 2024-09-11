namespace LeetCode.Problems._1342_Number_of_Steps_to_Reduce_a_Number_to_Zero;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumberOfSteps(testCase.Num), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Num { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
