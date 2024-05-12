using JetBrains.Annotations;

namespace LeetCode._0384_Shuffle_an_Array;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public ISolutionImpl Create(int[] nums) => new Solution(nums);

    private class Solution : ISolutionImpl
    {
        private readonly int[] _nums;
        private readonly Random _random = new();

        public Solution(IEnumerable<int> nums) => _nums = nums.ToArray();

        public int[] Reset() => _nums;
        public int[] Shuffle() => _nums.OrderBy(_ => _random.Next()).ToArray();
    }
}
