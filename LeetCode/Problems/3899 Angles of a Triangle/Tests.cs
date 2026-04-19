namespace LeetCode.Problems._3899_Angles_of_a_Triangle;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.InternalAngles(testCase.Sides), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Sides { get; [UsedImplicitly] init; } = null!;
        public double[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
