namespace LeetCode.Problems._0384_Shuffle_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/923229091/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ISolutionImpl Create(int[] nums) => new Solution(nums);

    private class Solution : ISolutionImpl
    {
        private readonly int[] _nums;
        private readonly Random _random = new();

        public Solution(IEnumerable<int> nums) => _nums = nums.ToArray();

        public int[] Reset() => _nums;

        public int[] Shuffle()
        {
            var n = _nums.Length;

            var result = new int[n];
            var indices = Enumerable.Range(0, n).ToList();

            for (var i = 0; i < n; i++)
            {
                var randomIndexOfIndices = _random.Next(indices.Count);
                var randomIndex = indices[randomIndexOfIndices];
                (indices[^1], indices[randomIndexOfIndices]) = (indices[randomIndexOfIndices], indices[^1]);
                indices.RemoveAt(indices.Count - 1);
                result[i] = _nums[randomIndex];
            }

            return result;
        }
    }
}
