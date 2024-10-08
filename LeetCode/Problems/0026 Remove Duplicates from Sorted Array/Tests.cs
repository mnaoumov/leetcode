namespace LeetCode.Problems._0026_Remove_Duplicates_from_Sorted_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var nums = testCase.Nums.ToArray();
        var k = solution.RemoveDuplicates(nums);

        Assert.That(k, Is.EqualTo(testCase.ExpectedNums.Length));

        Assert.That(nums.Take(k), Is.EqualTo(testCase.ExpectedNums));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int[] ExpectedNums { get; [UsedImplicitly] init; } = null!;
    }
}
