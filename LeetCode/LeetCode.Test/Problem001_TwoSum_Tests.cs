using LeetCode.Problem001_TwoSum;
using NUnit.Framework;

namespace LeetCode.Test
{
    [TestFixture(typeof(BruteForce))]
    [TestFixture(typeof(TwoPassDictionary))]
    [TestFixture(typeof(OnePassDictionary))]
    public class Problem001_TwoSum_Tests<TSolution> where TSolution : ISolution, new()
    {
        [Test]
        [TestCase(new[] { 2, 7, 11, 15 }, 9, ExpectedResult = new[] { 0, 1 })]
        [TestCase(new[] { 3, 2, 4 }, 6, ExpectedResult = new[] { 1, 2 })]
        public int[] TwoSum(int[] nums, int target)
        {
            var solution = new TSolution();
            return solution.TwoSum(nums, target);
        }
    }
}
