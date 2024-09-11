namespace LeetCode.Problems._1700_Number_of_Students_Unable_to_Eat_Lunch;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountStudents(testCase.Students, testCase.Sandwiches), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Students { get; [UsedImplicitly] init; } = null!;
        public int[] Sandwiches { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
