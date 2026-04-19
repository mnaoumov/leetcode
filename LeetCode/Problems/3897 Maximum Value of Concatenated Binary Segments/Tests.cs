namespace LeetCode.Problems._3897_Maximum_Value_of_Concatenated_Binary_Segments;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxValue(testCase.Nums1, testCase.Nums0), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums1 { get; [UsedImplicitly] init; } = null!;
        public int[] Nums0 { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
