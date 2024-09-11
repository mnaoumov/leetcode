namespace LeetCode.Problems._1385_Find_the_Distance_Value_Between_Two_Arrays;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindTheDistanceValue(testCase.Arr1, testCase.Arr2, testCase.D), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Arr1 { get; [UsedImplicitly] init; } = null!;
        public int[] Arr2 { get; [UsedImplicitly] init; } = null!;
        public int D { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
