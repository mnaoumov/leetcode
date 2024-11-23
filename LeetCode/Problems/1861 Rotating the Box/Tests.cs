namespace LeetCode.Problems._1861_Rotating_the_Box;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.RotateTheBox(testCase.Box), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public char[][] Box { get; [UsedImplicitly] init; } = null!;
        public char[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
