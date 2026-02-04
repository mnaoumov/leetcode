namespace LeetCode.Problems._1304_Find_N_Unique_Integers_Sum_up_to_Zero;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var arr = solution.SumZero(testCase.N);

        Assert.That(arr.Distinct().Count(), Is.EqualTo(testCase.N));
        Assert.That(arr.Sum(), Is.EqualTo(0));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
    }
}
