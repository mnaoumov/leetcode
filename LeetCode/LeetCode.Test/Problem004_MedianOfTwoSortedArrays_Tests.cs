using LeetCode.Problem004_MedianOfTwoSortedArrays;
using NUnit.Framework;

namespace LeetCode.Test
{
    [TestFixture(typeof(Solution))]
    public class Problem004_MedianOfTwoSortedArrays_Tests<TSolution> where TSolution : ISolution, new()
    {
        [Test]
        [TestCase(new[] { 1, 3 }, new[] { 2 }, ExpectedResult = 2.0)]
        [TestCase(new[] { 1, 2 }, new[] { 3, 4 }, ExpectedResult = 2.5)]
        [TestCase(new[] { 1, 2 }, new[] { 3, 4, 5 }, ExpectedResult = 3.0)]
        public double Test(int[] nums1, int[] nums2)
        {
            return new TSolution().FindMedianSortedArrays(nums1, nums2);
        }
    }
}