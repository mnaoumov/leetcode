namespace LeetCode.Problems._2554_Maximum_Number_of_Integers_to_Choose_From_a_Range_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxCount(testCase.Banned, testCase.N, testCase.MaxSum), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Banned { get; [UsedImplicitly] init; } = null!;
        public int N { get; [UsedImplicitly] init; }
        public int MaxSum { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
