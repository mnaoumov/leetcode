namespace LeetCode.Problems._3516_Find_Closest_Person;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindClosest(testCase.X, testCase.Y, testCase.Z), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int X { get; [UsedImplicitly] init; }
        public int Y { get; [UsedImplicitly] init; }
        public int Z { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
