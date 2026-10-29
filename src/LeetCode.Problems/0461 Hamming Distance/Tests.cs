namespace LeetCode.Problems._0461_Hamming_Distance;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.HammingDistance(testCase.X, testCase.Y), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int X { get; [UsedImplicitly] init; }
        public int Y { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
