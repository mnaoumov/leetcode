namespace LeetCode.Problems._1317_Convert_Integer_to_the_Sum_of_Two_No_Zero_Integers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        var arr = solution.GetNoZeroIntegers(testCase.N);

        Assert.That(arr.Length, Is.EqualTo(2));
        Assert.That(arr[0] + arr[1], Is.EqualTo(testCase.N));
        Assert.That(IsNoZero(arr[0]), Is.True);
        Assert.That(IsNoZero(arr[1]), Is.True);
    }

    private static bool IsNoZero(int n) => !n.ToString().Contains('0');

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
    }
}
