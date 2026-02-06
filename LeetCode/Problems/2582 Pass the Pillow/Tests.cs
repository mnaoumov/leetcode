namespace LeetCode.Problems._2582_Pass_the_Pillow;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.PassThePillow(testCase.N, testCase.Time), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int Time { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
