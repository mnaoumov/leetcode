namespace LeetCode.Problems._2327_Number_of_People_Aware_of_a_Secret;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.PeopleAwareOfSecret(testCase.N, testCase.Delay, testCase.Forget), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int Delay { get; [UsedImplicitly] init; }
        public int Forget { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
