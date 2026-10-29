namespace LeetCode.Problems._0451_Sort_Characters_By_Frequency;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        // ReSharper disable once CoVariantArrayConversion
        Assert.That(solution.FrequencySort(testCase.S), Is.AnyOf(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public string[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
