namespace LeetCode.Problems._1187_Make_Array_Strictly_Increasing;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MakeArrayIncreasing(testCase.Arr1, testCase.Arr2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Arr1 { get; [UsedImplicitly] init; } = null!;
        public int[] Arr2 { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
