namespace LeetCode.Problems._1865_Finding_Pairs_With_a_Certain_Sum;

/// <summary>
/// https://leetcode.com/problems/finding-pairs-with-a-certain-sum/submissions/1687818313/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IFindSumPairs Create(int[] nums1, int[] nums2) => new FindSumPairs(nums1, nums2);

    private class FindSumPairs : IFindSumPairs
    {
        private readonly int[] _nums1;
        private readonly int[] _nums2;
        private readonly Dictionary<int, int> _nums2Counts;

        public FindSumPairs(int[] nums1, int[] nums2)
        {
            _nums1 = nums1;
            _nums2 = nums2;
            _nums2Counts = nums2
                .GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    
        public void Add(int index, int val)
        {
            var num2 = _nums2[index];
            var nextNum2 = num2 + val;
            _nums2[index] = nextNum2;
            _nums2Counts[num2]--;
            _nums2Counts.TryAdd(nextNum2, 0);
            _nums2Counts[nextNum2]++;
        }

        public int Count(int tot) => _nums1.Sum(num1 => _nums2Counts.GetValueOrDefault(tot - num1, 0));
    }
}
