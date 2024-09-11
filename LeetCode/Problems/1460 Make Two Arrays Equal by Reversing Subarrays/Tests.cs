namespace LeetCode.Problems._1460_Make_Two_Arrays_Equal_by_Reversing_Subarrays;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CanBeEqual(testCase.Target, testCase.Arr), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Target { get; [UsedImplicitly] init; } = null!;
        public int[] Arr { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
