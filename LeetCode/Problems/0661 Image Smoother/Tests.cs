namespace LeetCode.Problems._0661_Image_Smoother;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ImageSmoother(testCase.Img), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Img { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
