using NUnit.Framework;

namespace LeetCode._026_Remove_Duplicates_from_Sorted_Array;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Test(
            nums: new[] { 1, 1, 2 },
            expectedNums: new[] { 1, 2 });
    }

    [Test]
    public void Example2()
    {
        Test(
            nums: new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 },
            expectedNums: new[] { 0, 1, 2, 3, 4 });
    }

    void Test(int[] nums, int[] expectedNums)
    {
        int k = Solution.RemoveDuplicates(nums);

        Assert.That(k, Is.EqualTo(expectedNums.Length));

        for (int i = 0; i < k; i++)
        {
            Assert.That(nums[i], Is.EqualTo(expectedNums[i]));
        }
    }
}