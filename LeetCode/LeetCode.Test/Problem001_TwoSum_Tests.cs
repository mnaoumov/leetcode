using LeetCode.Problem001_TwoSum;
using NUnit.Framework;

namespace LeetCode.Test
{
    public class Problem001_TwoSum_Tests
    {
        [Test]
        [TestCase(new[] { 2, 7, 11, 15 }, 9, ExpectedResult = new[] { 0, 1 })]
        public int[] TwoSum(int[] nums, int target)
        {
            var solution = new Solution();
            return solution.TwoSum(nums, target);
        }
    }
}
