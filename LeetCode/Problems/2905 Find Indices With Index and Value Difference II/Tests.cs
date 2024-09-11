namespace LeetCode.Problems._2905_Find_Indices_With_Index_and_Value_Difference_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var ans = solution.FindIndices(testCase.Nums, testCase.IndexDifference, testCase.ValueDifference);

        if (ans.SequenceEqual(new[] { -1, -1 }))
        {
            Assert.That(testCase.Output, Is.EqualTo(new[] { -1, -1 }));
        }
        else
        {
            Assert.That(Math.Abs(ans[0] - ans[1]), Is.GreaterThanOrEqualTo(testCase.IndexDifference));
            Assert.That(Math.Abs(testCase.Nums[ans[0]] - testCase.Nums[ans[1]]), Is.GreaterThanOrEqualTo(testCase.ValueDifference));
        }
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int IndexDifference { get; [UsedImplicitly] init; }
        public int ValueDifference { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
