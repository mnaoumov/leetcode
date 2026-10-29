namespace LeetCode.Problems._1257_Smallest_Common_Region;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindSmallestRegion(testCase.Regions, testCase.Region1, testCase.Region2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public IList<IList<string>> Regions { get; [UsedImplicitly] init; } = null!;
        public string Region1 { get; [UsedImplicitly] init; } = null!;
        public string Region2 { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
