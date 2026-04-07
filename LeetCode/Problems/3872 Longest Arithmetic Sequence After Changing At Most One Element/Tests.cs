namespace LeetCode.Problems._3872_Longest_Arithmetic_Sequence_After_Changing_At_Most_One_Element;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LongestArithmetic(testCase.Nums), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
[UsedImplicitly] init; } = null!;
[UsedImplicitly] init; }
    }
}
