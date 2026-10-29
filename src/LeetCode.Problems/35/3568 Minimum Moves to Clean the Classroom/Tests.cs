namespace LeetCode.Problems._3568_Minimum_Moves_to_Clean_the_Classroom;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinMoves(testCase.Classroom, testCase.Energy), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Classroom { get; [UsedImplicitly] init; } = null!;
        public int Energy { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
