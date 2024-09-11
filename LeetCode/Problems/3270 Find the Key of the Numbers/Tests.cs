namespace LeetCode.Problems._3270_Find_the_Key_of_the_Numbers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GenerateKey(testCase.Num1, testCase.Num2, testCase.Num3), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Num1 { get; [UsedImplicitly] init; }
        public int Num2 { get; [UsedImplicitly] init; }
        public int Num3 { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
