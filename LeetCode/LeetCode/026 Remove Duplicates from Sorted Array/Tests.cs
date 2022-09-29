using NUnit.Framework;

namespace LeetCode._026_Remove_Duplicates_from_Sorted_Array;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    [TestCase(new[] { 1, 1, 2 }, new[] { 1, 2 }, TestName = "Example1")]
    [TestCase(new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, new[] { 0, 1, 2, 3, 4 }, TestName = "Example2")]
    public void Test(int[] nums, int[] expectedNums)
    {
        int k = Solution.RemoveDuplicates(nums);

        Assert.That(k, Is.EqualTo(expectedNums.Length));

        Assert.That(nums.Take(k), Is.EqualTo(expectedNums));
    }
}