namespace LeetCode.Problems._2375_Construct_Smallest_Number_From_DI_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SmallestNumber(testCase.Pattern), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Pattern { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
