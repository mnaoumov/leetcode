namespace LeetCode.Problems._2169_Count_Operations_to_Obtain_Zero;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountOperations(testCase.Num1, testCase.Num2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Num1 { get; [UsedImplicitly] init; }
        public int Num2 { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
