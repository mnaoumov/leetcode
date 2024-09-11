namespace LeetCode.Problems._2598_Smallest_Missing_Non_negative_Integer_After_Operations;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindSmallestInteger(testCase.Nums, testCase.Value), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int Value { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
