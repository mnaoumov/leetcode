namespace LeetCode.Problems._1980_Find_Unique_Binary_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var n = testCase.Nums.Length;
        var ans = solution.FindDifferentBinaryString(testCase.Nums);

        Assert.That(ans, Has.Length.EqualTo(n));
        Assert.That(ans.ToCharArray().Distinct(), Is.SubsetOf(new[] { '0', '1' }));
        Assert.That(testCase.Nums, Does.Not.Contain(ans));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Nums { get; [UsedImplicitly] init; } = null!;
    }
}
