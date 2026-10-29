namespace LeetCode.Problems._2147_Number_of_Ways_to_Divide_a_Long_Corridor;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumberOfWays(testCase.Corridor), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Corridor { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
