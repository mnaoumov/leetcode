namespace LeetCode.Problems._3346_Maximum_Frequency_of_an_Element_After_Performing_Operations_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxFrequency(testCase.Nums, testCase.K, testCase.NumOperations), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int NumOperations { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
