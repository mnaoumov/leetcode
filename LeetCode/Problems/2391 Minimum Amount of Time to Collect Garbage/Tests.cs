namespace LeetCode.Problems._2391_Minimum_Amount_of_Time_to_Collect_Garbage;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GarbageCollection(testCase.Garbage, testCase.Travel), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Garbage { get; [UsedImplicitly] init; } = null!;
        public int[] Travel { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
