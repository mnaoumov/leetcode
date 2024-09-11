namespace LeetCode.Problems._1538_Guess_the_Majority_in_a_Hidden_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var ans = solution.GuessMajority(new ArrayReader(testCase.Nums));
        var countZero = testCase.Nums.Count(num => num == 0);

        var n = testCase.Nums.Length;

        if (2 * countZero == n)
        {
            Assert.That(ans, Is.EqualTo(-1));
            return;
        }

        Assert.That(ans, Is.InRange(0, n - 1));

        var majorityElement = 2 * countZero > n ? 0 : 1;
        Assert.That(testCase.Nums[ans], Is.EqualTo(majorityElement));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
    }
}
